using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookCategoryRepository : IBookCategoryRepository
{
    private readonly LibraryDbContext _context;

    public BookCategoryRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<BookCategory?> GetByIdAsync(Guid id)
    {
        return await _context.BookCategories.FindAsync(id);
    }

    public async Task<IEnumerable<BookCategory>> GetAllAsync()
    {
        return await _context.BookCategories.ToListAsync();
    }

    public async Task<BookCategory?> GetByNameAsync(string name)
    {
        return await _context.BookCategories
            .FirstOrDefaultAsync(c => c.Name == name);
    }

    public async Task<BookCategory?> GetWithBooksAsync(Guid id)
    {
        return await _context.BookCategories
            .Include(c => c.Books)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(BookCategory entity)
    {
        await _context.BookCategories.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(BookCategory entity)
    {
        _context.BookCategories.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await _context.BookCategories.FindAsync(id);
        if (category is not null)
        {
            _context.BookCategories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
