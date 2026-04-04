using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IBookCategoryRepository : IRepository<BookCategory>
{
    Task<BookCategory?> GetByNameAsync(string name);
    Task<BookCategory?> GetWithBooksAsync(Guid id);
    Task<IEnumerable<BookCategory>> GetActiveCategoriesAsync();
    Task<IEnumerable<BookCategory>> GetRootCategoriesAsync();
    Task<IEnumerable<BookCategory>> GetSubCategoriesAsync(Guid parentId);
}
