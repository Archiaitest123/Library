using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class FinesController : ControllerBase
{
    private readonly IFineService _fineService;

    public FinesController(IFineService fineService)
    {
        _fineService = fineService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<FineDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<FineDto>>> GetAll()
    {
        var fines = await _fineService.GetAllAsync();
        return Ok(fines);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FineDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FineDto>> GetById(Guid id)
    {
        var fine = await _fineService.GetByIdAsync(id);
        if (fine is null)
            return NotFound();

        return Ok(fine);
    }

    [HttpGet("customer/{customerId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<FineDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<FineDto>>> GetByCustomer(Guid customerId)
    {
        var fines = await _fineService.GetByCustomerIdAsync(customerId);
        return Ok(fines);
    }

    [HttpGet("customer/{customerId:guid}/total-unpaid")]
    [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
    public async Task<ActionResult<decimal>> GetTotalUnpaid(Guid customerId)
    {
        var total = await _fineService.GetTotalUnpaidByCustomerAsync(customerId);
        return Ok(total);
    }

    [HttpGet("pending")]
    [ProducesResponseType(typeof(IEnumerable<FineDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<FineDto>>> GetPending()
    {
        var fines = await _fineService.GetPendingFinesAsync();
        return Ok(fines);
    }

    [HttpPost]
    [ProducesResponseType(typeof(FineDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<FineDto>> Create([FromBody] CreateFineDto createDto)
    {
        var fine = await _fineService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = fine.Id }, fine);
    }

    [HttpPost("{id:guid}/pay")]
    [ProducesResponseType(typeof(FineDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FineDto>> PayFine(Guid id, [FromBody] PayFineDto payDto)
    {
        var fine = await _fineService.PayFineAsync(id, payDto);
        return Ok(fine);
    }

    [HttpPost("{id:guid}/waive")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> WaiveFine(Guid id)
    {
        await _fineService.WaiveFineAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _fineService.DeleteAsync(id);
        return NoContent();
    }
}
