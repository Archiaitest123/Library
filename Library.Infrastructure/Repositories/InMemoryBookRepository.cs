using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.Infrastructure.Repositories;

public class InMemoryBookRepository : IBookRepository
{
    private readonly List<Book> _books = [];

    public Task<Book?> GetByIdAsync(Guid id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        return Task.FromResult(book);
    }

    public Task<IEnumerable<Book>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Book>>(_books);
    }

    public Task<IEnumerable<Book>> GetAvailableBooksAsync()
    {
        var available = _books.Where(b => b.IsAvailable);
        return Task.FromResult<IEnumerable<Book>>(available);
    }

    public Task<Book?> GetByISBNAsync(string isbn)
    {
        var book = _books.FirstOrDefault(b => b.ISBN == isbn);
        return Task.FromResult(book);
    }

    public Task AddAsync(Book entity)
    {
        _books.Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Book entity)
    {
        var index = _books.FindIndex(b => b.Id == entity.Id);
        if (index != -1)
        {
            _books[index] = entity;
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book is not null)
        {
            _books.Remove(book);
        }
        return Task.CompletedTask;
    }
}
