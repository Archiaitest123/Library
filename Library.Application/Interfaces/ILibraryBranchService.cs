using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface ILibraryBranchService
{
    Task<LibraryBranchDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<LibraryBranchDto>> GetAllAsync();
    Task<IEnumerable<LibraryBranchDto>> GetActiveBranchesAsync();
    Task<LibraryBranchDto> CreateAsync(CreateLibraryBranchDto createDto);
    Task UpdateAsync(Guid id, UpdateLibraryBranchDto updateDto);
    Task DeleteAsync(Guid id);
}
