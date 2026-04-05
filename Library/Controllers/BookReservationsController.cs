using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Authorize(Policy = "LibrarianOrAdmin")]
public class BookReservationsController : ControllerBase
{
    private readonly IBookReservationService _reservationService;
    private readonly IReservationQueueService _queueService;

    public BookReservationsController(
        IBookReservationService reservationService,
        IReservationQueueService queueService)
    {
        _reservationService = reservationService;
        _queueService = queueService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BookReservationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookReservationDto>>> GetAll()
    {
        var reservations = await _reservationService.GetAllAsync();
        return Ok(reservations);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BookReservationDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookReservationDto>> GetById(Guid id)
    {
        var reservation = await _reservationService.GetByIdAsync(id);
        if (reservation is null)
            return NotFound();

        return Ok(reservation);
    }

    [HttpGet("customer/{customerId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<BookReservationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookReservationDto>>> GetByCustomer(Guid customerId)
    {
        var reservations = await _reservationService.GetByCustomerIdAsync(customerId);
        return Ok(reservations);
    }

    [HttpGet("book/{bookId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<BookReservationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookReservationDto>>> GetByBook(Guid bookId)
    {
        var reservations = await _reservationService.GetByBookIdAsync(bookId);
        return Ok(reservations);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BookReservationDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookReservationDto>> Create([FromBody] CreateBookReservationDto createDto)
    {
        var reservation = await _reservationService.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation);
    }

    [HttpPost("{id:guid}/cancel")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Cancel(Guid id)
    {
        await _reservationService.CancelReservationAsync(id);
        return NoContent();
    }

    [HttpPost("{id:guid}/fulfill")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Fulfill(Guid id)
    {
        await _reservationService.FulfillReservationAsync(id);
        return NoContent();
    }

    [HttpPost("prioritized")]
    [ProducesResponseType(typeof(BookReservationDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<BookReservationDto>> CreatePrioritized([FromBody] CreateBookReservationDto createDto)
    {
        var reservation = await _queueService.CreatePrioritizedReservationAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation);
    }

    [HttpGet("queue/{bookId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<BookReservationDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<BookReservationDto>>> GetQueue(Guid bookId)
    {
        var queue = await _queueService.GetQueueByBookAsync(bookId);
        return Ok(queue);
    }

    [HttpGet("queue/{bookId:guid}/status")]
    [ProducesResponseType(typeof(ReservationQueueStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReservationQueueStatusDto>> GetQueueStatus(Guid bookId)
    {
        var status = await _queueService.GetQueueStatusAsync(bookId);
        return Ok(status);
    }

    [HttpPost("{id:guid}/cancel-requeue")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CancelAndRequeue(Guid id)
    {
        await _queueService.CancelAndRequeueAsync(id);
        return NoContent();
    }

    [HttpPost("process-expired")]
    [Authorize(Policy = "AdminOnly")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<ActionResult<int>> ProcessExpired()
    {
        var count = await _queueService.ProcessExpiredReservationsAsync();
        return Ok(count);
    }

    [HttpPost("queue/{bookId:guid}/promote")]
    [ProducesResponseType(typeof(BookReservationDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookReservationDto?>> PromoteNext(Guid bookId)
    {
        var promoted = await _queueService.PromoteNextInQueueAsync(bookId);
        if (promoted is null)
            return Ok(null);

        return Ok(promoted);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _reservationService.DeleteAsync(id);
        return NoContent();
    }
}
