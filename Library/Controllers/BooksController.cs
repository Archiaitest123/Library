using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Authorize(Policy = "LibrarianOrAdmin")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookDto>> GetById(Guid id)
    {
        var book = await _bookService.GetByIdAsync(id);
        if (book is null)
            return NotFound();

        return Ok(book);
    }

    [HttpGet("available")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAvailable()
    {
        var books = await _bookService.GetAvailableBooksAsync();
        return Ok(books);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BookDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<BookDto>> Create([FromBody] CreateBookDto createBookDto)
    {
        var book = await _bookService.CreateAsync(createBookDto);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto updateBookDto)
    {
        await _bookService.UpdateAsync(id, updateBookDto);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _bookService.DeleteAsync(id);
        return NoContent();
    }
}
