using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StaffController : ControllerBase
{
    private readonly IStaffService _staffService;

    public StaffController(IStaffService staffService)
    {
        _staffService = staffService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StaffDto>>> GetAll()
    {
        var staffList = await _staffService.GetAllAsync();
        return Ok(staffList);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StaffDto>> GetById(Guid id)
    {
        var staff = await _staffService.GetByIdAsync(id);
        if (staff is null)
            return NotFound();

        return Ok(staff);
    }

    [HttpGet("active")]
    public async Task<ActionResult<IEnumerable<StaffDto>>> GetActive()
    {
        var staffList = await _staffService.GetActiveStaffAsync();
        return Ok(staffList);
    }

    [HttpPost]
    public async Task<ActionResult<StaffDto>> Create([FromBody] CreateStaffDto createDto)
    {
        var staff = await _staffService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = staff.Id }, staff);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStaffDto updateDto)
    {
        try
        {
            await _staffService.UpdateAsync(id, updateDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _staffService.DeleteAsync(id);
        return NoContent();
    }
}
