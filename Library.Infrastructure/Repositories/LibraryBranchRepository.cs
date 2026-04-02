using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class LibraryBranchRepository : BaseRepository<LibraryBranch>, ILibraryBranchRepository
{
    public LibraryBranchRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<LibraryBranch>> GetActiveBranchesAsync()
    {
        return await _dbSet.Where(lb => lb.IsActive).ToListAsync();
    }

    public async Task<LibraryBranch?> GetWithStaffAsync(Guid id)
    {
        return await _dbSet
            .Include(lb => lb.Staff)
            .FirstOrDefaultAsync(lb => lb.Id == id);
    }

    public async Task<LibraryBranch?> GetWithBooksAsync(Guid id)
    {
        return await _dbSet
            .Include(lb => lb.Books)
            .FirstOrDefaultAsync(lb => lb.Id == id);
    }
}
