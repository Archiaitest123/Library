using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Authorize(Policy = "MemberOrAbove")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationsController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet("customer/{customerId:guid}")]
    [ProducesResponseType(typeof(IEnumerable<NotificationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<NotificationDto>>> GetByCustomer(Guid customerId)
    {
        var notifications = await _notificationService.GetByCustomerIdAsync(customerId);
        return Ok(notifications);
    }

    [HttpGet("customer/{customerId:guid}/unread")]
    [ProducesResponseType(typeof(IEnumerable<NotificationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<NotificationDto>>> GetUnread(Guid customerId)
    {
        var notifications = await _notificationService.GetUnreadByCustomerIdAsync(customerId);
        return Ok(notifications);
    }

    [HttpGet("customer/{customerId:guid}/unread-count")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<ActionResult<int>> GetUnreadCount(Guid customerId)
    {
        var count = await _notificationService.GetUnreadCountAsync(customerId);
        return Ok(count);
    }

    [HttpPost]
    [ProducesResponseType(typeof(NotificationDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<NotificationDto>> Create([FromBody] CreateNotificationDto createDto)
    {
        var notification = await _notificationService.CreateAsync(createDto);
        return Created(string.Empty, notification);
    }

    [HttpPost("{id:guid}/read")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> MarkAsRead(Guid id)
    {
        await _notificationService.MarkAsReadAsync(id);
        return NoContent();
    }

    [HttpPost("customer/{customerId:guid}/read-all")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> MarkAllAsRead(Guid customerId)
    {
        await _notificationService.MarkAllAsReadAsync(customerId);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _notificationService.DeleteAsync(id);
        return NoContent();
    }
}
