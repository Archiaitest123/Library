using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class StaffController : ControllerBase
{
    private readonly IStaffService _staffService;

    public StaffController(IStaffService staffService)
    {
        _staffService = staffService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<StaffDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<StaffDto>>> GetAll()
    {
        var staffList = await _staffService.GetAllAsync();
        return Ok(staffList);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(StaffDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StaffDto>> GetById(Guid id)
    {
        var staff = await _staffService.GetByIdAsync(id);
        if (staff is null)
            return NotFound();

        return Ok(staff);
    }

    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<StaffDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<StaffDto>>> GetActive()
    {
        var staffList = await _staffService.GetActiveStaffAsync();
        return Ok(staffList);
    }

    [HttpPost]
    [ProducesResponseType(typeof(StaffDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<StaffDto>> Create([FromBody] CreateStaffDto createDto)
    {
        var staff = await _staffService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = staff.Id }, staff);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStaffDto updateDto)
    {
        await _staffService.UpdateAsync(id, updateDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _staffService.DeleteAsync(id);
        return NoContent();
    }
}
