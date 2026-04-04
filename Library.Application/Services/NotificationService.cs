using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationService(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<IEnumerable<NotificationDto>> GetByCustomerIdAsync(Guid customerId)
    {
        var notifications = await _notificationRepository.GetByCustomerIdAsync(customerId);
        return notifications.Select(n => n.ToDto());
    }

    public async Task<IEnumerable<NotificationDto>> GetUnreadByCustomerIdAsync(Guid customerId)
    {
        var notifications = await _notificationRepository.GetUnreadByCustomerIdAsync(customerId);
        return notifications.Select(n => n.ToDto());
    }

    public async Task<int> GetUnreadCountAsync(Guid customerId)
    {
        return await _notificationRepository.GetUnreadCountByCustomerIdAsync(customerId);
    }

    public async Task<NotificationDto> CreateAsync(CreateNotificationDto createDto)
    {
        var notification = createDto.ToEntity();
        await _notificationRepository.AddAsync(notification);
        return notification.ToDto();
    }

    public async Task MarkAsReadAsync(Guid id)
    {
        await _notificationRepository.MarkAsReadAsync(id);
    }

    public async Task MarkAllAsReadAsync(Guid customerId)
    {
        await _notificationRepository.MarkAllAsReadAsync(customerId);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _notificationRepository.DeleteAsync(id);
    }
}
