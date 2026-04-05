using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class MembershipSummaryDto
{
    public Guid CustomerId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string MembershipNumber { get; set; } = string.Empty;
    public MembershipType MembershipType { get; set; }
    public bool IsActive { get; set; }
    public DateTime? MembershipExpiryDate { get; set; }
    public bool IsMembershipExpired { get; set; }

    public LoanSummaryDto Loans { get; set; } = new();
    public ReservationSummaryDto Reservations { get; set; } = new();
    public FinancialSummaryDto Financial { get; set; } = new();
    public PolicySummaryDto Policy { get; set; } = new();
    public EligibilitySummaryDto Eligibility { get; set; } = new();
    public ReadingStatsSummaryDto ReadingStats { get; set; } = new();
}

public class LoanSummaryDto
{
    public int ActiveCount { get; set; }
    public int OverdueCount { get; set; }
    public int TotalHistoricalCount { get; set; }
    public List<ActiveLoanItemDto> ActiveLoans { get; set; } = [];
}

public class ActiveLoanItemDto
{
    public Guid LoanId { get; set; }
    public Guid BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public bool IsOverdue { get; set; }
    public int DaysUntilDue { get; set; }
    public int RenewalCount { get; set; }
    public int RenewalsRemaining { get; set; }
}

public class ReservationSummaryDto
{
    public int ActiveCount { get; set; }
    public int MaxAllowed { get; set; }
    public int RemainingSlots { get; set; }
}

public class FinancialSummaryDto
{
    public decimal OutstandingFines { get; set; }
    public decimal MaxAllowedFines { get; set; }
    public bool HasBlockingFines { get; set; }
}

public class PolicySummaryDto
{
    public int MaxBooksAllowed { get; set; }
    public int MaxLoanDurationDays { get; set; }
    public int MaxRenewals { get; set; }
    public decimal DailyLateFeeRate { get; set; }
}

public class EligibilitySummaryDto
{
    public bool CanBorrow { get; set; }
    public bool CanReserve { get; set; }
    public List<string> BlockingReasons { get; set; } = [];
    public int RemainingLoanSlots { get; set; }
}

public class ReadingStatsSummaryDto
{
    public int TotalBooksRead { get; set; }
    public int TotalReviews { get; set; }
    public double AverageRatingGiven { get; set; }
}
