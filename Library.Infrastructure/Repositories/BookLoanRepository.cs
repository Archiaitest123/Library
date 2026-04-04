using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookLoanRepository : BaseRepository<BookLoan>, IBookLoanRepository
{
    public BookLoanRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<BookLoan>> GetByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .Include(l => l.Book)
            .Include(l => l.Customer)
            .Where(l => l.CustomerId == customerId)
            .OrderByDescending(l => l.LoanDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookLoan>> GetByBookIdAsync(Guid bookId)
    {
        return await _dbSet
            .Include(l => l.Customer)
            .Where(l => l.BookId == bookId)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookLoan>> GetActiveLoansAsync()
    {
        return await _dbSet
            .Include(l => l.Book)
            .Include(l => l.Customer)
            .Where(l => l.Status == LoanStatus.Active)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookLoan>> GetOverdueLoansAsync()
    {
        return await _dbSet
            .Include(l => l.Book)
            .Include(l => l.Customer)
            .Where(l => l.Status == LoanStatus.Active && l.DueDate < DateTime.UtcNow)
            .ToListAsync();
    }

    public async Task<IEnumerable<BookLoan>> GetByStatusAsync(LoanStatus status)
    {
        return await _dbSet
            .Include(l => l.Book)
            .Include(l => l.Customer)
            .Where(l => l.Status == status)
            .ToListAsync();
    }

    public async Task<BookLoan?> GetWithDetailsAsync(Guid id)
    {
        return await _dbSet
            .Include(l => l.Book)
            .Include(l => l.Customer)
            .Include(l => l.ProcessedByUser)
            .Include(l => l.Fines)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<int> GetActiveLoanCountByCustomerAsync(Guid customerId)
    {
        return await _dbSet
            .CountAsync(l => l.CustomerId == customerId && l.Status == LoanStatus.Active);
    }
}
