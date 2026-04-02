using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(LibraryDbContext context) : base(context) { }

    public async Task<Customer?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<Customer?> GetByMembershipNumberAsync(string membershipNumber)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.MembershipNumber == membershipNumber);
    }

    public async Task<IEnumerable<Customer>> GetActiveCustomersAsync()
    {
        return await _dbSet.Where(c => c.IsActive).ToListAsync();
    }

    public async Task<Customer?> GetWithLoansAsync(Guid id)
    {
        return await _dbSet
            .Include(c => c.BookLoans)
                .ThenInclude(l => l.Book)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Customer?> GetWithReservationsAsync(Guid id)
    {
        return await _dbSet
            .Include(c => c.BookReservations)
                .ThenInclude(r => r.Book)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Customer>> SearchAsync(string searchTerm)
    {
        return await _dbSet
            .Where(c => c.FirstName.Contains(searchTerm)
                || c.LastName.Contains(searchTerm)
                || c.Email.Contains(searchTerm)
                || c.MembershipNumber.Contains(searchTerm))
            .ToListAsync();
    }
}
