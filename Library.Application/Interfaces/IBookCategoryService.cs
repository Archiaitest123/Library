using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IBookCategoryService
{
    Task<BookCategoryDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<BookCategoryDto>> GetAllAsync();
    Task<BookCategoryDto> CreateAsync(CreateBookCategoryDto createDto);
    Task UpdateAsync(Guid id, UpdateBookCategoryDto updateDto);
    Task DeleteAsync(Guid id);
}
