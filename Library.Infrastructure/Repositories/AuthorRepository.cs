using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
{
    public AuthorRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<Author>> SearchAsync(string searchTerm)
    {
        return await _dbSet
            .Where(a => a.FirstName.Contains(searchTerm)
                || a.LastName.Contains(searchTerm))
            .ToListAsync();
    }

    public async Task<Author?> GetWithBooksAsync(Guid id)
    {
        return await _dbSet
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
