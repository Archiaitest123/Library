using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/loan-policies")]
[Produces("application/json")]
public class LoanPoliciesController : ControllerBase
{
    private readonly ILoanPolicyService _loanPolicyService;

    public LoanPoliciesController(ILoanPolicyService loanPolicyService)
    {
        _loanPolicyService = loanPolicyService;
    }

    /// <summary>
    /// Returns the loan policy for every membership type.
    /// </summary>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<LoanPolicyDto>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<LoanPolicyDto>> GetAll()
    {
        var policies = Enum.GetValues<MembershipType>()
            .Select(BuildPolicy);

        return Ok(policies);
    }

    /// <summary>
    /// Returns the loan policy for the specified membership type.
    /// </summary>
    [HttpGet("{membershipType}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoanPolicyDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<LoanPolicyDto> GetByMembershipType(MembershipType membershipType)
    {
        if (!Enum.IsDefined(membershipType))
            return BadRequest($"Unknown membership type: {membershipType}");

        return Ok(BuildPolicy(membershipType));
    }

    /// <summary>
    /// Calculates the late fee for a loan based on due date, return date, and membership type.
    /// </summary>
    [HttpPost("calculate-late-fee")]
    [Authorize]
    [ProducesResponseType(typeof(LateFeeCalculationResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<LateFeeCalculationResultDto> CalculateLateFee(
        [FromBody] LateFeeCalculationRequestDto request)
    {
        if (request.ReturnDate < request.DueDate.AddDays(-365))
            return BadRequest("Return date is implausibly early.");

        var isLate = request.ReturnDate > request.DueDate;
        var daysLate = isLate
            ? (int)Math.Ceiling((request.ReturnDate - request.DueDate).TotalDays)
            : 0;

        var fee = _loanPolicyService.CalculateLateFee(request.DueDate, request.ReturnDate, request.MembershipType);
        var dailyRate = _loanPolicyService.GetDailyLateFeeRate(request.MembershipType);

        return Ok(new LateFeeCalculationResultDto
        {
            LateFee = fee,
            DaysLate = daysLate,
            DailyRate = dailyRate,
            IsLate = isLate
        });
    }

    private LoanPolicyDto BuildPolicy(MembershipType membershipType) => new()
    {
        MembershipType = membershipType,
        MaxLoanDurationDays = _loanPolicyService.GetMaxLoanDurationDays(membershipType),
        MaxBooksAllowed = _loanPolicyService.GetMaxBooksAllowed(membershipType),
        MaxRenewals = _loanPolicyService.GetMaxRenewals(membershipType),
        DailyLateFeeRate = _loanPolicyService.GetDailyLateFeeRate(membershipType),
        MaxOutstandingFinesAllowed = _loanPolicyService.GetMaxOutstandingFinesAllowed(membershipType)
    };
}
