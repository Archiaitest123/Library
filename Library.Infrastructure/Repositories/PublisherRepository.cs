using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
{
    public PublisherRepository(LibraryDbContext context) : base(context) { }

    public async Task<Publisher?> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task<Publisher?> GetWithBooksAsync(Guid id)
    {
        return await _dbSet
            .Include(p => p.Books)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Publisher>> GetActivePublishersAsync()
    {
        return await _dbSet.Where(p => p.IsActive).ToListAsync();
    }
}
