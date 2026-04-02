using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Authorize(Policy = "LibrarianOrAdmin")]
public class BookLoansController : ControllerBase
{
    private readonly IBookLoanService _loanService;

    public BookLoansController(IBookLoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BookLoanDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookLoanDto>>> GetAll()
    {
        var loans = await _loanService.GetAllAsync();
        return Ok(loans);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BookLoanDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookLoanDto>> GetById(Guid id)
    {
        var loan = await _loanService.GetByIdAsync(id);
        if (loan is null)
            return NotFound();

        return Ok(loan);
    }

    [HttpGet("customer/{customerId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<BookLoanDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookLoanDto>>> GetByCustomer(Guid customerId)
    {
        var loans = await _loanService.GetByCustomerIdAsync(customerId);
        return Ok(loans);
    }

    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<BookLoanDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookLoanDto>>> GetActive()
    {
        var loans = await _loanService.GetActiveLoansAsync();
        return Ok(loans);
    }

    [HttpGet("overdue")]
    [ProducesResponseType(typeof(IEnumerable<BookLoanDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookLoanDto>>> GetOverdue()
    {
        var loans = await _loanService.GetOverdueLoansAsync();
        return Ok(loans);
    }

    [HttpGet("status/{status}")]
    [ProducesResponseType(typeof(IEnumerable<BookLoanDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookLoanDto>>> GetByStatus(LoanStatus status)
    {
        var loans = await _loanService.GetByStatusAsync(status);
        return Ok(loans);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BookLoanDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookLoanDto>> Create([FromBody] CreateBookLoanDto createDto)
    {
        var loan = await _loanService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = loan.Id }, loan);
    }

    [HttpPost("{id:guid}/return")]
    [ProducesResponseType(typeof(BookLoanDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookLoanDto>> ReturnBook(Guid id, [FromBody] ReturnBookLoanDto returnDto)
    {
        var loan = await _loanService.ReturnBookAsync(id, returnDto);
        return Ok(loan);
    }

    [HttpPost("{id:guid}/renew")]
    [ProducesResponseType(typeof(BookLoanDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookLoanDto>> RenewLoan(Guid id, [FromBody] RenewBookLoanDto renewDto)
    {
        var loan = await _loanService.RenewLoanAsync(id, renewDto);
        return Ok(loan);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _loanService.DeleteAsync(id);
        return NoContent();
    }
}
