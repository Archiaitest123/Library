using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    Task<IEnumerable<Book>> GetAvailableBooksAsync();
    Task<Book?> GetByISBNAsync(string isbn);
    Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId);
    Task<IEnumerable<Book>> GetByCategoryIdAsync(Guid categoryId);
    Task<IEnumerable<Book>> GetByBranchIdAsync(Guid branchId);
    Task<IEnumerable<Book>> GetByPublisherIdAsync(Guid publisherId);
    Task<IEnumerable<Book>> SearchAsync(string searchTerm);
    Task<Book?> GetWithDetailsAsync(Guid id);
}
