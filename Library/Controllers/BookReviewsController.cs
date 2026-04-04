using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Authorize(Policy = "MemberOrAbove")]
public class BookReviewsController : ControllerBase
{
    private readonly IBookReviewService _reviewService;

    public BookReviewsController(IBookReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("book/{bookId:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<BookReviewDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookReviewDto>>> GetByBook(Guid bookId)
    {
        var reviews = await _reviewService.GetByBookIdAsync(bookId);
        return Ok(reviews);
    }

    [HttpGet("customer/{customerId:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<BookReviewDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookReviewDto>>> GetByCustomer(Guid customerId)
    {
        var reviews = await _reviewService.GetByCustomerIdAsync(customerId);
        return Ok(reviews);
    }

    [HttpGet("book/{bookId:guid}/average-rating")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
    public async Task<ActionResult<double>> GetAverageRating(Guid bookId)
    {
        var rating = await _reviewService.GetAverageRatingAsync(bookId);
        return Ok(rating);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(BookReviewDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookReviewDto>> GetById(Guid id)
    {
        var review = await _reviewService.GetByIdAsync(id);
        if (review is null)
            return NotFound();

        return Ok(review);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BookReviewDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BookReviewDto>> Create([FromBody] CreateBookReviewDto createDto)
    {
        var review = await _reviewService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = review.Id }, review);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookReviewDto updateDto)
    {
        await _reviewService.UpdateAsync(id, updateDto);
        return NoContent();
    }

    [HttpPost("{id:guid}/approve")]
    [Authorize(Policy = "LibrarianOrAdmin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Approve(Guid id)
    {
        await _reviewService.ApproveReviewAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _reviewService.DeleteAsync(id);
        return NoContent();
    }
}
