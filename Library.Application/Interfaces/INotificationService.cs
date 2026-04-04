using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface INotificationService
{
    Task<IEnumerable<NotificationDto>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<NotificationDto>> GetUnreadByCustomerIdAsync(Guid customerId);
    Task<int> GetUnreadCountAsync(Guid customerId);
    Task<NotificationDto> CreateAsync(CreateNotificationDto createDto);
    Task MarkAsReadAsync(Guid id);
    Task MarkAllAsReadAsync(Guid customerId);
    Task DeleteAsync(Guid id);
}
