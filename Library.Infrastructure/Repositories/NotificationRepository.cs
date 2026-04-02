using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
{
    public NotificationRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<Notification>> GetByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .Where(n => n.CustomerId == customerId)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Notification>> GetUnreadByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .Where(n => n.CustomerId == customerId && !n.IsRead)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
    }

    public async Task<int> GetUnreadCountByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .CountAsync(n => n.CustomerId == customerId && !n.IsRead);
    }

    public async Task MarkAsReadAsync(Guid id)
    {
        var notification = await _dbSet.FindAsync(id);
        if (notification is not null)
        {
            notification.IsRead = true;
            notification.ReadAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }

    public async Task MarkAllAsReadAsync(Guid customerId)
    {
        var unread = await _dbSet
            .Where(n => n.CustomerId == customerId && !n.IsRead)
            .ToListAsync();

        foreach (var notification in unread)
        {
            notification.IsRead = true;
            notification.ReadAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
    }
}
