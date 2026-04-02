using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<AuthorDto?> GetByIdAsync(Guid id)
    {
        var author = await _authorRepository.GetWithBooksAsync(id);
        return author?.ToDto();
    }

    public async Task<IEnumerable<AuthorDto>> GetAllAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        return authors.Select(a => a.ToDto());
    }

    public async Task<IEnumerable<AuthorDto>> SearchAsync(string searchTerm)
    {
        var authors = await _authorRepository.SearchAsync(searchTerm);
        return authors.Select(a => a.ToDto());
    }

    public async Task<AuthorDto> CreateAsync(CreateAuthorDto createDto)
    {
        var author = createDto.ToEntity();
        await _authorRepository.AddAsync(author);
        return author.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateAuthorDto updateDto)
    {
        var author = await _authorRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.Author), id);

        updateDto.UpdateEntity(author);
        await _authorRepository.UpdateAsync(author);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _authorRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.Author), id);

        await _authorRepository.DeleteAsync(id);
    }
}
