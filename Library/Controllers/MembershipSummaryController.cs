using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/customers/{customerId:guid}/membership-summary")]
[Produces("application/json")]
[Authorize]
public class MembershipSummaryController : ControllerBase
{
    private readonly IMembershipSummaryService _membershipSummaryService;

    public MembershipSummaryController(IMembershipSummaryService membershipSummaryService)
    {
        _membershipSummaryService = membershipSummaryService;
    }

    /// <summary>
    /// Returns a full membership snapshot for a customer:
    /// active loans, reservations, outstanding fines, applicable policy,
    /// borrow/reserve eligibility, and reading statistics.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(MembershipSummaryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MembershipSummaryDto>> GetSummary(Guid customerId)
    {
        var summary = await _membershipSummaryService.GetSummaryAsync(customerId);
        return Ok(summary);
    }
}
