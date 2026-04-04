using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface ILibraryBranchRepository : IRepository<LibraryBranch>
{
    Task<IEnumerable<LibraryBranch>> GetActiveBranchesAsync();
    Task<LibraryBranch?> GetWithUsersAsync(Guid id);
    Task<LibraryBranch?> GetWithBooksAsync(Guid id);
}
