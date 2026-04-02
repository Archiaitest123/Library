using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Authorize(Policy = "LibrarianOrAdmin")]
public class LibraryBranchesController : ControllerBase
{
    private readonly ILibraryBranchService _branchService;

    public LibraryBranchesController(ILibraryBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<LibraryBranchDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<LibraryBranchDto>>> GetAll()
    {
        var branches = await _branchService.GetAllAsync();
        return Ok(branches);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LibraryBranchDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LibraryBranchDto>> GetById(Guid id)
    {
        var branch = await _branchService.GetByIdAsync(id);
        if (branch is null)
            return NotFound();

        return Ok(branch);
    }

    [HttpGet("active")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<LibraryBranchDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<LibraryBranchDto>>> GetActive()
    {
        var branches = await _branchService.GetActiveBranchesAsync();
        return Ok(branches);
    }

    [HttpPost]
    [ProducesResponseType(typeof(LibraryBranchDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<LibraryBranchDto>> Create([FromBody] CreateLibraryBranchDto createDto)
    {
        var branch = await _branchService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = branch.Id }, branch);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLibraryBranchDto updateDto)
    {
        await _branchService.UpdateAsync(id, updateDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _branchService.DeleteAsync(id);
        return NoContent();
    }
}
