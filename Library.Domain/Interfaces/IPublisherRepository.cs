using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IPublisherRepository : IRepository<Publisher>
{
    Task<Publisher?> GetByNameAsync(string name);
    Task<Publisher?> GetWithBooksAsync(Guid id);
    Task<IEnumerable<Publisher>> GetActivePublishersAsync();
}
