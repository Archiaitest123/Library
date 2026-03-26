using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IBookService
{
    Task<BookDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<BookDto>> GetAllAsync();
    Task<IEnumerable<BookDto>> GetAvailableBooksAsync();
    Task<BookDto> CreateAsync(CreateBookDto createBookDto);
    Task UpdateAsync(Guid id, UpdateBookDto updateBookDto);
    Task DeleteAsync(Guid id);
}
