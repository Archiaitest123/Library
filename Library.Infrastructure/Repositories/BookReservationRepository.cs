using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookReservationRepository : BaseRepository<BookReservation>, IBookReservationRepository
{
    public BookReservationRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<BookReservation>> GetByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .Include(r => r.Book)
            .Where(r => r.CustomerId == customerId)
            .OrderByDescending(r => r.ReservationDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookReservation>> GetByBookIdAsync(Guid bookId)
    {
        return await _dbSet
            .Include(r => r.Customer)
            .Where(r => r.BookId == bookId)
            .OrderBy(r => r.QueuePosition)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookReservation>> GetByStatusAsync(ReservationStatus status)
    {
        return await _dbSet
            .Include(r => r.Book)
            .Include(r => r.Customer)
            .Where(r => r.Status == status)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookReservation>> GetExpiredReservationsAsync()
    {
        return await _dbSet
            .Include(r => r.Book)
            .Include(r => r.Customer)
            .Where(r => r.Status == ReservationStatus.Pending && r.ExpiryDate < DateTime.UtcNow)
            .ToListAsync();
    }

    public async Task<BookReservation?> GetWithDetailsAsync(Guid id)
    {
        return await _dbSet
            .Include(r => r.Book)
            .Include(r => r.Customer)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}
