using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IAuthorService
{
    Task<AuthorDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<AuthorDto>> GetAllAsync();
    Task<IEnumerable<AuthorDto>> SearchAsync(string searchTerm);
    Task<AuthorDto> CreateAsync(CreateAuthorDto createDto);
    Task UpdateAsync(Guid id, UpdateAuthorDto updateDto);
    Task DeleteAsync(Guid id);
}
