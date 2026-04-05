using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class MembershipSummaryService : IMembershipSummaryService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IBookLoanRepository _loanRepository;
    private readonly IBookReservationRepository _reservationRepository;
    private readonly IFineRepository _fineRepository;
    private readonly IBookReviewRepository _reviewRepository;
    private readonly ILoanPolicyService _loanPolicyService;
    private readonly IReservationQueueService _reservationQueueService;

    public MembershipSummaryService(
        ICustomerRepository customerRepository,
        IBookLoanRepository loanRepository,
        IBookReservationRepository reservationRepository,
        IFineRepository fineRepository,
        IBookReviewRepository reviewRepository,
        ILoanPolicyService loanPolicyService,
        IReservationQueueService reservationQueueService)
    {
        _customerRepository = customerRepository;
        _loanRepository = loanRepository;
        _reservationRepository = reservationRepository;
        _fineRepository = fineRepository;
        _reviewRepository = reviewRepository;
        _loanPolicyService = loanPolicyService;
        _reservationQueueService = reservationQueueService;
    }

    public async Task<MembershipSummaryDto> GetSummaryAsync(Guid customerId)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId)
            ?? throw new NotFoundException(nameof(Customer), customerId);

        var loansTask = _loanRepository.GetByCustomerIdAsync(customerId);
        var reservationsTask = _reservationRepository.GetByCustomerIdAsync(customerId);
        var outstandingFinesTask = _fineRepository.GetTotalUnpaidFinesByCustomerAsync(customerId);
        var reviewsTask = _reviewRepository.GetByCustomerIdAsync(customerId);

        await Task.WhenAll(loansTask, reservationsTask, outstandingFinesTask, reviewsTask);

        var loans = loansTask.Result.ToList();
        var reservations = reservationsTask.Result.ToList();
        var outstandingFines = outstandingFinesTask.Result;
        var reviews = reviewsTask.Result.ToList();

        var now = DateTime.UtcNow;

        var activeLoans = loans
            .Where(l => l.Status == LoanStatus.Active || l.Status == LoanStatus.Overdue)
            .ToList();

        var overdueLoans = activeLoans
            .Where(l => l.DueDate < now)
            .ToList();

        var returnedLoans = loans
            .Where(l => l.Status == LoanStatus.Returned)
            .ToList();

        var activeReservations = reservations
            .Where(r => r.Status == ReservationStatus.Pending || r.Status == ReservationStatus.Confirmed)
            .ToList();

        var isMembershipExpired = customer.MembershipExpiryDate.HasValue
            && customer.MembershipExpiryDate.Value < now;

        var maxBooks = _loanPolicyService.GetMaxBooksAllowed(customer.MembershipType);
        var maxFines = _loanPolicyService.GetMaxOutstandingFinesAllowed(customer.MembershipType);
        var maxReservations = _reservationQueueService.GetMaxActiveReservations(customer.MembershipType);
        var maxRenewals = _loanPolicyService.GetMaxRenewals(customer.MembershipType);

        var blockingReasons = BuildBorrowBlockingReasons(
            customer, isMembershipExpired, activeLoans.Count, maxBooks, outstandingFines, maxFines);

        var reservationBlockingReasons = BuildReservationBlockingReasons(
            customer, isMembershipExpired, activeReservations.Count, maxReservations, outstandingFines);

        var averageRating = reviews.Count > 0
            ? Math.Round(reviews.Average(r => r.Rating), 2)
            : 0.0;

        return new MembershipSummaryDto
        {
            CustomerId = customer.Id,
            FullName = $"{customer.FirstName} {customer.LastName}",
            MembershipNumber = customer.MembershipNumber,
            MembershipType = customer.MembershipType,
            IsActive = customer.IsActive,
            MembershipExpiryDate = customer.MembershipExpiryDate,
            IsMembershipExpired = isMembershipExpired,

            Loans = new LoanSummaryDto
            {
                ActiveCount = activeLoans.Count,
                OverdueCount = overdueLoans.Count,
                TotalHistoricalCount = returnedLoans.Count,
                ActiveLoans = activeLoans
                    .Select(l => new ActiveLoanItemDto
                    {
                        LoanId = l.Id,
                        BookId = l.BookId,
                        BookTitle = l.Book?.Title ?? string.Empty,
                        DueDate = l.DueDate,
                        IsOverdue = l.DueDate < now,
                        DaysUntilDue = (int)Math.Floor((l.DueDate - now).TotalDays),
                        RenewalCount = l.RenewalCount,
                        RenewalsRemaining = Math.Max(0, maxRenewals - l.RenewalCount)
                    })
                    .OrderBy(l => l.DueDate)
                    .ToList()
            },

            Reservations = new ReservationSummaryDto
            {
                ActiveCount = activeReservations.Count,
                MaxAllowed = maxReservations,
                RemainingSlots = Math.Max(0, maxReservations - activeReservations.Count)
            },

            Financial = new FinancialSummaryDto
            {
                OutstandingFines = outstandingFines,
                MaxAllowedFines = maxFines,
                HasBlockingFines = outstandingFines > maxFines
            },

            Policy = new PolicySummaryDto
            {
                MaxBooksAllowed = maxBooks,
                MaxLoanDurationDays = _loanPolicyService.GetMaxLoanDurationDays(customer.MembershipType),
                MaxRenewals = maxRenewals,
                DailyLateFeeRate = _loanPolicyService.GetDailyLateFeeRate(customer.MembershipType)
            },

            Eligibility = new EligibilitySummaryDto
            {
                CanBorrow = blockingReasons.Count == 0,
                CanReserve = reservationBlockingReasons.Count == 0,
                BlockingReasons = blockingReasons,
                RemainingLoanSlots = Math.Max(0, maxBooks - activeLoans.Count)
            },

            ReadingStats = new ReadingStatsSummaryDto
            {
                TotalBooksRead = returnedLoans.Count,
                TotalReviews = reviews.Count,
                AverageRatingGiven = averageRating
            }
        };
    }

    private static List<string> BuildBorrowBlockingReasons(
        Customer customer,
        bool isMembershipExpired,
        int activeLoanCount,
        int maxBooks,
        decimal outstandingFines,
        decimal maxFines)
    {
        var reasons = new List<string>();

        if (!customer.IsActive)
            reasons.Add("Account is inactive or suspended.");

        if (isMembershipExpired)
            reasons.Add($"Membership expired on {customer.MembershipExpiryDate!.Value:yyyy-MM-dd}.");

        if (activeLoanCount >= maxBooks)
            reasons.Add($"Maximum loan limit reached ({activeLoanCount}/{maxBooks} books).");

        if (outstandingFines > maxFines)
            reasons.Add($"Outstanding fines ({outstandingFines:C}) exceed the allowed limit ({maxFines:C}).");

        return reasons;
    }

    private static List<string> BuildReservationBlockingReasons(
        Customer customer,
        bool isMembershipExpired,
        int activeReservationCount,
        int maxReservations,
        decimal outstandingFines)
    {
        var reasons = new List<string>();

        if (!customer.IsActive)
            reasons.Add("Account is inactive or suspended.");

        if (isMembershipExpired)
            reasons.Add($"Membership expired on {customer.MembershipExpiryDate!.Value:yyyy-MM-dd}.");

        if (outstandingFines > 0)
            reasons.Add($"Unpaid fines ({outstandingFines:C}) must be cleared before making reservations.");

        if (activeReservationCount >= maxReservations)
            reasons.Add($"Maximum active reservation limit reached ({activeReservationCount}/{maxReservations}).");

        return reasons;
    }
}
