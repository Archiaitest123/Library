using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Authorize]
public class BookRecommendationsController : ControllerBase
{
    private readonly IBookRecommendationService _recommendationService;

    public BookRecommendationsController(IBookRecommendationService recommendationService)
    {
        _recommendationService = recommendationService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<BookRecommendationDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<BookRecommendationDto>>> GetRecommendations(
        [FromBody] RecommendationRequestDto request)
    {
        var recommendations = await _recommendationService.GetRecommendationsAsync(request);
        return Ok(recommendations);
    }

    [HttpGet("profile/{customerId:guid}")]
    [ProducesResponseType(typeof(CustomerReadingProfileDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerReadingProfileDto>> GetReadingProfile(Guid customerId)
    {
        var profile = await _recommendationService.GetReadingProfileAsync(customerId);
        return Ok(profile);
    }

    [HttpGet("trending")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<BookRecommendationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookRecommendationDto>>> GetTrending(
        [FromQuery] int count = 10)
    {
        var trending = await _recommendationService.GetTrendingBooksAsync(count);
        return Ok(trending);
    }

    [HttpGet("similar/{bookId:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<BookRecommendationDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<BookRecommendationDto>>> GetSimilarBooks(
        Guid bookId, [FromQuery] int count = 5)
    {
        var similar = await _recommendationService.GetSimilarBooksAsync(bookId, count);
        return Ok(similar);
    }
}
