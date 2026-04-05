using Library.Domain.Enums;

namespace Library.Application.Interfaces;

public interface ILoanPolicyService
{
    int GetMaxLoanDurationDays(MembershipType membershipType);
    int GetMaxBooksAllowed(MembershipType membershipType);
    int GetMaxRenewals(MembershipType membershipType);
    decimal GetDailyLateFeeRate(MembershipType membershipType);
    decimal CalculateLateFee(DateTime dueDate, DateTime returnDate, MembershipType membershipType);
    bool IsEligibleForLoan(bool isActive, DateTime? membershipExpiryDate, int activeLoans, MembershipType membershipType);
    decimal GetMaxOutstandingFinesAllowed(MembershipType membershipType);
}
