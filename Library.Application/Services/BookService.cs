using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookDto?> GetByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetWithDetailsAsync(id);
        return book?.ToDto();
    }

    public async Task<IEnumerable<BookDto>> GetAllAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return books.Select(b => b.ToDto());
    }

    public async Task<IEnumerable<BookDto>> GetAvailableBooksAsync()
    {
        var books = await _bookRepository.GetAvailableBooksAsync();
        return books.Select(b => b.ToDto());
    }

    public async Task<BookDto> CreateAsync(CreateBookDto createBookDto)
    {
        var existingBook = await _bookRepository.GetByISBNAsync(createBookDto.ISBN);
        if (existingBook is not null)
            throw new ConflictException($"A book with ISBN '{createBookDto.ISBN}' already exists.");

        var book = createBookDto.ToEntity();
        await _bookRepository.AddAsync(book);
        return book.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)
    {
        var book = await _bookRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.Book), id);

        updateBookDto.UpdateEntity(book);
        await _bookRepository.UpdateAsync(book);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _bookRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.Book), id);

        await _bookRepository.DeleteAsync(id);
    }
}
