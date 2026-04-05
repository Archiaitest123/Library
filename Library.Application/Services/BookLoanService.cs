using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Enums;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class BookLoanService : IBookLoanService
{
    private readonly IBookLoanRepository _loanRepository;
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IFineRepository _fineRepository;
    private readonly ILoanPolicyService _loanPolicyService;

    public BookLoanService(
        IBookLoanRepository loanRepository,
        IBookRepository bookRepository,
        ICustomerRepository customerRepository,
        IFineRepository fineRepository,
        ILoanPolicyService loanPolicyService)
    {
        _loanRepository = loanRepository;
        _bookRepository = bookRepository;
        _customerRepository = customerRepository;
        _fineRepository = fineRepository;
        _loanPolicyService = loanPolicyService;
    }

    public async Task<BookLoanDto?> GetByIdAsync(Guid id)
    {
        var loan = await _loanRepository.GetWithDetailsAsync(id);
        return loan?.ToDto();
    }

    public async Task<IEnumerable<BookLoanDto>> GetAllAsync()
    {
        var loans = await _loanRepository.GetAllAsync();
        return loans.Select(l => l.ToDto());
    }

    public async Task<IEnumerable<BookLoanDto>> GetByCustomerIdAsync(Guid customerId)
    {
        var loans = await _loanRepository.GetByCustomerIdAsync(customerId);
        return loans.Select(l => l.ToDto());
    }

    public async Task<IEnumerable<BookLoanDto>> GetActiveLoansAsync()
    {
        var loans = await _loanRepository.GetActiveLoansAsync();
        return loans.Select(l => l.ToDto());
    }

    public async Task<IEnumerable<BookLoanDto>> GetOverdueLoansAsync()
    {
        var loans = await _loanRepository.GetOverdueLoansAsync();
        return loans.Select(l => l.ToDto());
    }

    public async Task<IEnumerable<BookLoanDto>> GetByStatusAsync(LoanStatus status)
    {
        var loans = await _loanRepository.GetByStatusAsync(status);
        return loans.Select(l => l.ToDto());
    }

    public async Task<BookLoanDto> CreateAsync(CreateBookLoanDto createDto)
    {
        var book = await _bookRepository.GetByIdAsync(createDto.BookId)
            ?? throw new NotFoundException(nameof(Domain.Entities.Book), createDto.BookId);

        if (book.AvailableCopies <= 0)
            throw new BadRequestException("No available copies of this book.");

        var customer = await _customerRepository.GetByIdAsync(createDto.CustomerId)
            ?? throw new NotFoundException(nameof(Domain.Entities.Customer), createDto.CustomerId);

        // Check membership eligibility using policy service
        var activeLoans = await _loanRepository.GetActiveLoanCountByCustomerAsync(createDto.CustomerId);
        var maxBooks = _loanPolicyService.GetMaxBooksAllowed(customer.MembershipType);

        if (!_loanPolicyService.IsEligibleForLoan(
                customer.IsActive,
                customer.MembershipExpiryDate,
                activeLoans,
                customer.MembershipType))
        {
            if (!customer.IsActive)
                throw new BadRequestException("Customer membership is not active.");

            if (customer.MembershipExpiryDate.HasValue && customer.MembershipExpiryDate.Value < DateTime.UtcNow)
                throw new BadRequestException("Customer membership has expired.");

            throw new BadRequestException($"Customer has reached the maximum loan limit of {maxBooks} for {customer.MembershipType} membership.");
        }

        // Check outstanding fines
        var outstandingFines = await _fineRepository.GetTotalUnpaidFinesByCustomerAsync(createDto.CustomerId);
        var maxFinesAllowed = _loanPolicyService.GetMaxOutstandingFinesAllowed(customer.MembershipType);
        if (outstandingFines > maxFinesAllowed)
            throw new BadRequestException(
                $"Customer has outstanding fines of {outstandingFines:C} which exceeds the maximum allowed ({maxFinesAllowed:C}) for {customer.MembershipType} membership. Please pay fines before borrowing.");

        // Check for duplicate active loan for the same book
        var customerLoans = await _loanRepository.GetByCustomerIdAsync(createDto.CustomerId);
        var hasActiveBookLoan = customerLoans.Any(l =>
            l.BookId == createDto.BookId &&
            (l.Status == LoanStatus.Active || l.Status == LoanStatus.Overdue));
        if (hasActiveBookLoan)
            throw new BadRequestException("Customer already has an active loan for this book.");

        // Apply policy-based loan duration
        var loanDuration = createDto.LoanDurationDays > 0
            ? Math.Min(createDto.LoanDurationDays, _loanPolicyService.GetMaxLoanDurationDays(customer.MembershipType))
            : _loanPolicyService.GetMaxLoanDurationDays(customer.MembershipType);

        var loan = createDto.ToEntity(loanDuration, _loanPolicyService.GetMaxRenewals(customer.MembershipType));
        await _loanRepository.AddAsync(loan);

        book.AvailableCopies--;
        if (book.AvailableCopies == 0)
            book.IsAvailable = false;
        await _bookRepository.UpdateAsync(book);

        return loan.ToDto();
    }

    public async Task<BookLoanDto> ReturnBookAsync(Guid id, ReturnBookLoanDto returnDto)
    {
        var loan = await _loanRepository.GetWithDetailsAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookLoan), id);

        if (loan.Status != LoanStatus.Active && loan.Status != LoanStatus.Overdue)
            throw new BadRequestException("This loan is not active.");

        var returnDate = DateTime.UtcNow;
        loan.ReturnDate = returnDate;
        loan.Status = LoanStatus.Returned;
        loan.Notes = returnDto.Notes;
        loan.UpdatedAt = returnDate;

        // Auto-calculate and create late fee if overdue
        var customer = await _customerRepository.GetByIdAsync(loan.CustomerId);
        if (customer is not null && returnDate > loan.DueDate)
        {
            var lateFee = _loanPolicyService.CalculateLateFee(loan.DueDate, returnDate, customer.MembershipType);
            if (lateFee > 0)
            {
                var daysLate = (int)Math.Ceiling((returnDate - loan.DueDate).TotalDays);
                var fine = new Domain.Entities.Fine
                {
                    Id = Guid.NewGuid(),
                    BookLoanId = loan.Id,
                    CustomerId = loan.CustomerId,
                    Amount = lateFee,
                    Reason = $"Late return fee: {daysLate} day(s) overdue at {_loanPolicyService.GetDailyLateFeeRate(customer.MembershipType):C}/day",
                    Status = FineStatus.Pending,
                    CreatedAt = returnDate
                };
                await _fineRepository.AddAsync(fine);
            }
        }

        await _loanRepository.UpdateAsync(loan);

        var book = await _bookRepository.GetByIdAsync(loan.BookId);
        if (book is not null)
        {
            book.AvailableCopies++;
            book.IsAvailable = true;
            await _bookRepository.UpdateAsync(book);
        }

        return loan.ToDto();
    }

    public async Task<BookLoanDto> RenewLoanAsync(Guid id, RenewBookLoanDto renewDto)
    {
        var loan = await _loanRepository.GetWithDetailsAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookLoan), id);

        if (loan.Status != LoanStatus.Active)
            throw new BadRequestException("Only active loans can be renewed.");

        // Use policy-based max renewals
        var customer = await _customerRepository.GetByIdAsync(loan.CustomerId);
        var maxRenewals = customer is not null
            ? _loanPolicyService.GetMaxRenewals(customer.MembershipType)
            : loan.MaxRenewals;

        if (loan.RenewalCount >= maxRenewals)
            throw new BadRequestException($"Maximum renewal limit ({maxRenewals}) reached for {customer?.MembershipType} membership.");

        // Check outstanding fines before allowing renewal
        if (customer is not null)
        {
            var outstandingFines = await _fineRepository.GetTotalUnpaidFinesByCustomerAsync(customer.Id);
            var maxFinesAllowed = _loanPolicyService.GetMaxOutstandingFinesAllowed(customer.MembershipType);
            if (outstandingFines > maxFinesAllowed)
                throw new BadRequestException(
                    $"Cannot renew: outstanding fines ({outstandingFines:C}) exceed the allowed limit ({maxFinesAllowed:C}). Please pay fines first.");
        }

        var maxDuration = customer is not null
            ? _loanPolicyService.GetMaxLoanDurationDays(customer.MembershipType)
            : 14;
        var additionalDays = Math.Min(renewDto.AdditionalDays, maxDuration);

        loan.DueDate = loan.DueDate.AddDays(additionalDays);
        loan.RenewalCount++;
        loan.MaxRenewals = maxRenewals;
        loan.UpdatedAt = DateTime.UtcNow;
        await _loanRepository.UpdateAsync(loan);

        return loan.ToDto();
    }

    public async Task<LoanEligibilityResultDto> CheckEligibilityAsync(Guid customerId)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId)
            ?? throw new NotFoundException(nameof(Domain.Entities.Customer), customerId);

        var activeLoans = await _loanRepository.GetActiveLoanCountByCustomerAsync(customerId);
        var maxBooks = _loanPolicyService.GetMaxBooksAllowed(customer.MembershipType);
        var outstandingFines = await _fineRepository.GetTotalUnpaidFinesByCustomerAsync(customerId);
        var maxFines = _loanPolicyService.GetMaxOutstandingFinesAllowed(customer.MembershipType);
        var isEligible = _loanPolicyService.IsEligibleForLoan(
            customer.IsActive, customer.MembershipExpiryDate, activeLoans, customer.MembershipType);

        var reasons = new List<string>();

        if (!customer.IsActive)
            reasons.Add("Customer membership is not active.");

        if (customer.MembershipExpiryDate.HasValue && customer.MembershipExpiryDate.Value < DateTime.UtcNow)
            reasons.Add($"Membership expired on {customer.MembershipExpiryDate.Value:yyyy-MM-dd}.");

        if (activeLoans >= maxBooks)
            reasons.Add($"Active loan limit reached ({activeLoans}/{maxBooks}).");

        if (outstandingFines > maxFines)
        {
            reasons.Add($"Outstanding fines ({outstandingFines:C}) exceed the limit ({maxFines:C}).");
            isEligible = false;
        }

        return new LoanEligibilityResultDto
        {
            IsEligible = isEligible,
            Reasons = reasons,
            CurrentActiveLoans = activeLoans,
            MaxBooksAllowed = maxBooks,
            RemainingSlots = Math.Max(0, maxBooks - activeLoans),
            RecommendedLoanDurationDays = _loanPolicyService.GetMaxLoanDurationDays(customer.MembershipType),
            OutstandingFines = outstandingFines,
            MaxOutstandingFinesAllowed = maxFines
        };
    }

    public async Task<LateFeeCalculationDto> CalculateLateFeeAsync(Guid loanId)
    {
        var loan = await _loanRepository.GetWithDetailsAsync(loanId)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookLoan), loanId);

        var customer = await _customerRepository.GetByIdAsync(loan.CustomerId)
            ?? throw new NotFoundException(nameof(Domain.Entities.Customer), loan.CustomerId);

        var returnDate = loan.ReturnDate ?? DateTime.UtcNow;
        var daysLate = returnDate > loan.DueDate
            ? (int)Math.Ceiling((returnDate - loan.DueDate).TotalDays)
            : 0;

        var dailyRate = _loanPolicyService.GetDailyLateFeeRate(customer.MembershipType);
        var rawFee = daysLate * dailyRate;
        var calculatedFee = _loanPolicyService.CalculateLateFee(loan.DueDate, returnDate, customer.MembershipType);

        return new LateFeeCalculationDto
        {
            LoanId = loanId,
            DueDate = loan.DueDate,
            ReturnDate = returnDate,
            DaysLate = daysLate,
            DailyRate = dailyRate,
            CalculatedFee = calculatedFee,
            WasCapped = rawFee > calculatedFee,
            MaxFee = calculatedFee < rawFee ? calculatedFee : rawFee
        };
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _loanRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.BookLoan), id);

        await _loanRepository.DeleteAsync(id);
    }
}
