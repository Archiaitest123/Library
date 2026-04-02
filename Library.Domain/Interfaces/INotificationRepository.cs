using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface INotificationRepository : IRepository<Notification>
{
    Task<IEnumerable<Notification>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<Notification>> GetUnreadByCustomerIdAsync(Guid customerId);
    Task<int> GetUnreadCountByCustomerIdAsync(Guid customerId);
    Task MarkAsReadAsync(Guid id);
    Task MarkAllAsReadAsync(Guid customerId);
}
