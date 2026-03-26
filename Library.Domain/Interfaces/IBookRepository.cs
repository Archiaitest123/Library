using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    Task<IEnumerable<Book>> GetAvailableBooksAsync();
    Task<Book?> GetByISBNAsync(string isbn);
}
