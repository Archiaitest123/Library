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

    public BookLoanService(
        IBookLoanRepository loanRepository,
        IBookRepository bookRepository,
        ICustomerRepository customerRepository)
    {
        _loanRepository = loanRepository;
        _bookRepository = bookRepository;
        _customerRepository = customerRepository;
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

        if (!customer.IsActive)
            throw new BadRequestException("Customer membership is not active.");

        var activeLoanCount = await _loanRepository.GetActiveLoanCountByCustomerAsync(createDto.CustomerId);
        if (activeLoanCount >= customer.MaxBooksAllowed)
            throw new BadRequestException($"Customer has reached the maximum loan limit of {customer.MaxBooksAllowed}.");

        var loan = createDto.ToEntity();
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

        loan.ReturnDate = DateTime.UtcNow;
        loan.Status = LoanStatus.Returned;
        loan.Notes = returnDto.Notes;
        loan.UpdatedAt = DateTime.UtcNow;
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

        if (loan.RenewalCount >= loan.MaxRenewals)
            throw new BadRequestException($"Maximum renewal limit ({loan.MaxRenewals}) reached.");

        loan.DueDate = loan.DueDate.AddDays(renewDto.AdditionalDays);
        loan.RenewalCount++;
        loan.UpdatedAt = DateTime.UtcNow;
        await _loanRepository.UpdateAsync(loan);

        return loan.ToDto();
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _loanRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.BookLoan), id);

        await _loanRepository.DeleteAsync(id);
    }
}
