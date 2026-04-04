using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(LibraryDbContext context) : base(context) { }

    public async Task<IEnumerable<Book>> GetAvailableBooksAsync()
    {
        return await _dbSet
            .Include(b => b.Author)
            .Include(b => b.BookCategory)
            .Where(b => b.IsAvailable)
            .ToListAsync();
    }

    public async Task<Book?> GetByISBNAsync(string isbn)
    {
        return await _dbSet
            .Include(b => b.Author)
            .FirstOrDefaultAsync(b => b.ISBN == isbn);
    }

    public async Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId)
    {
        return await _dbSet
            .Include(b => b.Author)
            .Include(b => b.BookCategory)
            .Where(b => b.AuthorId == authorId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetByCategoryIdAsync(Guid categoryId)
    {
        return await _dbSet
            .Include(b => b.Author)
            .Where(b => b.BookCategoryId == categoryId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetByBranchIdAsync(Guid branchId)
    {
        return await _dbSet
            .Include(b => b.Author)
            .Where(b => b.LibraryBranchId == branchId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetByPublisherIdAsync(Guid publisherId)
    {
        return await _dbSet
            .Include(b => b.Author)
            .Where(b => b.PublisherId == publisherId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> SearchAsync(string searchTerm)
    {
        return await _dbSet
            .Include(b => b.Author)
            .Include(b => b.BookCategory)
            .Where(b => b.Title.Contains(searchTerm)
                || b.ISBN.Contains(searchTerm)
                || b.Author.FirstName.Contains(searchTerm)
                || b.Author.LastName.Contains(searchTerm))
            .ToListAsync();
    }

    public async Task<Book?> GetWithDetailsAsync(Guid id)
    {
        return await _dbSet
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .Include(b => b.BookCategory)
            .Include(b => b.LibraryBranch)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}
