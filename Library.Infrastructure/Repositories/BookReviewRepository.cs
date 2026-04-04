using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookReviewRepository : BaseRepository<BookReview>, IBookReviewRepository
{
    public BookReviewRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<BookReview>> GetByBookIdAsync(Guid bookId)
    {
        return await _dbSet
            .Include(r => r.Customer)
            .Where(r => r.BookId == bookId)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookReview>> GetByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .Include(r => r.Book)
            .Where(r => r.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookReview>> GetApprovedReviewsByBookAsync(Guid bookId)
    {
        return await _dbSet
            .Include(r => r.Customer)
            .Where(r => r.BookId == bookId && r.IsApproved)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task<double> GetAverageRatingByBookAsync(Guid bookId)
    {
        var reviews = await _dbSet
            .Where(r => r.BookId == bookId && r.IsApproved)
            .ToListAsync();

        return reviews.Count != 0 ? reviews.Average(r => r.Rating) : 0;
    }
}
