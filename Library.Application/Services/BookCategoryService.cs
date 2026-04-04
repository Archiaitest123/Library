using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class BookCategoryService : IBookCategoryService
{
    private readonly IBookCategoryRepository _categoryRepository;

    public BookCategoryService(IBookCategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<BookCategoryDto?> GetByIdAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        return category?.ToDto();
    }

    public async Task<IEnumerable<BookCategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return categories.Select(c => c.ToDto());
    }

    public async Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto)
    {
        var existing = await _categoryRepository.GetByNameAsync(createDto.Name);
        if (existing is not null)
            throw new ConflictException($"Category with name '{createDto.Name}' already exists.");

        var category = createDto.ToEntity();
        await _categoryRepository.AddAsync(category);
        return category.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto)
    {
        var category = await _categoryRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookCategory), id);

        updateDto.UpdateEntity(category);
        await _categoryRepository.UpdateAsync(category);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _categoryRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.BookCategory), id);

        await _categoryRepository.DeleteAsync(id);
    }
}
