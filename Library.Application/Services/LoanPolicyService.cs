using Library.Application.Interfaces;
using Library.Domain.Enums;

namespace Library.Application.Services;

public class LoanPolicyService : ILoanPolicyService
{
    public int GetMaxLoanDurationDays(MembershipType membershipType)
    {
        return membershipType switch
        {
            MembershipType.Premium => 30,
            MembershipType.Standard => 21,
            MembershipType.Student => 28,
            MembershipType.Senior => 28,
            MembershipType.Basic => 14,
            _ => 14
        };
    }

    public int GetMaxBooksAllowed(MembershipType membershipType)
    {
        return membershipType switch
        {
            MembershipType.Premium => 10,
            MembershipType.Standard => 7,
            MembershipType.Student => 8,
            MembershipType.Senior => 6,
            MembershipType.Basic => 3,
            _ => 3
        };
    }

    public int GetMaxRenewals(MembershipType membershipType)
    {
        return membershipType switch
        {
            MembershipType.Premium => 5,
            MembershipType.Standard => 3,
            MembershipType.Student => 3,
            MembershipType.Senior => 4,
            MembershipType.Basic => 1,
            _ => 1
        };
    }

    public decimal GetDailyLateFeeRate(MembershipType membershipType)
    {
        return membershipType switch
        {
            MembershipType.Premium => 0.25m,
            MembershipType.Standard => 0.50m,
            MembershipType.Student => 0.15m,
            MembershipType.Senior => 0.10m,
            MembershipType.Basic => 0.75m,
            _ => 0.75m
        };
    }

    public decimal CalculateLateFee(DateTime dueDate, DateTime returnDate, MembershipType membershipType)
    {
        if (returnDate <= dueDate)
            return 0m;

        var daysLate = (int)Math.Ceiling((returnDate - dueDate).TotalDays);
        var dailyRate = GetDailyLateFeeRate(membershipType);
        var fee = daysLate * dailyRate;

        var maxFee = GetMaxFee(membershipType);
        return Math.Min(fee, maxFee);
    }

    public bool IsEligibleForLoan(bool isActive, DateTime? membershipExpiryDate, int activeLoans, MembershipType membershipType)
    {
        if (!isActive)
            return false;

        if (membershipExpiryDate.HasValue && membershipExpiryDate.Value < DateTime.UtcNow)
            return false;

        var maxBooks = GetMaxBooksAllowed(membershipType);
        if (activeLoans >= maxBooks)
            return false;

        return true;
    }

    public decimal GetMaxOutstandingFinesAllowed(MembershipType membershipType)
    {
        return membershipType switch
        {
            MembershipType.Premium => 50.00m,
            MembershipType.Standard => 25.00m,
            MembershipType.Student => 15.00m,
            MembershipType.Senior => 20.00m,
            MembershipType.Basic => 10.00m,
            _ => 10.00m
        };
    }

    private static decimal GetMaxFee(MembershipType membershipType)
    {
        return membershipType switch
        {
            MembershipType.Premium => 15.00m,
            MembershipType.Standard => 25.00m,
            MembershipType.Student => 10.00m,
            MembershipType.Senior => 10.00m,
            MembershipType.Basic => 30.00m,
            _ => 30.00m
        };
    }
}
