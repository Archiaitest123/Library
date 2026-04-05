using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class LoanPolicyDto
{
    public MembershipType MembershipType { get; set; }
    public int MaxLoanDurationDays { get; set; }
    public int MaxBooksAllowed { get; set; }
    public int MaxRenewals { get; set; }
    public decimal DailyLateFeeRate { get; set; }
    public decimal MaxOutstandingFinesAllowed { get; set; }
}

public class LateFeeCalculationRequestDto
{
    public DateTime DueDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public MembershipType MembershipType { get; set; }
}

public class LateFeeCalculationResultDto
{
    public decimal LateFee { get; set; }
    public int DaysLate { get; set; }
    public decimal DailyRate { get; set; }
    public bool IsLate { get; set; }
}
