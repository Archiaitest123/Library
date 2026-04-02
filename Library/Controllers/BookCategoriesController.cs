using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Authorize(Policy = "LibrarianOrAdmin")]
public class BookCategoriesController : ControllerBase
{
    private readonly IBookCategoryService _categoryService;

    public BookCategoriesController(IBookCategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<BookCategoryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookCategoryDto>>> GetAll()
    {
        var categories = await _categoryService.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(BookCategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookCategoryDto>> GetById(Guid id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        if (category is null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    [Authorize(Policy = "LibrarianOrAdmin")]
    [ProducesResponseType(typeof(BookCategoryDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<BookCategoryDto>> Create([FromBody] CreateBookCategoryDto createDto)
    {
        var category = await _categoryService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = "LibrarianOrAdmin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookCategoryDto updateDto)
    {
        await _categoryService.UpdateAsync(id, updateDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "LibrarianOrAdmin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _categoryService.DeleteAsync(id);
        return NoContent();
    }
}
