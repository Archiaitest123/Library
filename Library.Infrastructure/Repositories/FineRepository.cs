using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class FineRepository : BaseRepository<Fine>, IFineRepository
{
    public FineRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<Fine>> GetByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .Include(f => f.BookLoan)
                .ThenInclude(l => l.Book)
            .Where(f => f.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Fine>> GetByStatusAsync(FineStatus status)
    {
        return await _dbSet
            .Include(f => f.Customer)
            .Where(f => f.Status == status)
            .ToListAsync();
    }

    public async Task<IEnumerable<Fine>> GetPendingFinesAsync()
    {
        return await _dbSet
            .Include(f => f.Customer)
            .Include(f => f.BookLoan)
                .ThenInclude(l => l.Book)
            .Where(f => f.Status == FineStatus.Pending)
            .ToListAsync();
    }

    public async Task<decimal> GetTotalUnpaidFinesByCustomerAsync(Guid customerId)
    {
        return await _dbSet
            .Where(f => f.CustomerId == customerId && f.Status == FineStatus.Pending)
            .SumAsync(f => f.Amount);
    }
}
