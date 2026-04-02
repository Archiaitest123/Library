using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IAuthorRepository : IRepository<Author>
{
    Task<IEnumerable<Author>> SearchAsync(string searchTerm);
    Task<Author?> GetWithBooksAsync(Guid id);
}
