using Library.Application.DTOs;
using Library.Application.Email;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IEmailService _emailService;
    private readonly EmailSettings _emailSettings;

    public BookService(IBookRepository bookRepository, IEmailService emailService, EmailSettings emailSettings)
    {
        _bookRepository = bookRepository;
        _emailService = emailService;
        _emailSettings = emailSettings;
    }

    public async Task<BookDto?> GetByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
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
        var book = createBookDto.ToEntity();
        await _bookRepository.AddAsync(book);
        await SendBookAddedNotificationAsync(book);
        return book.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateBookDto updateBookDto)
    {
        var book = await _bookRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Book with id {id} not found.");

        updateBookDto.UpdateEntity(book);
        await _bookRepository.UpdateAsync(book);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _bookRepository.DeleteAsync(id);
    }

    private Task SendBookAddedNotificationAsync(Book book)
    {
        if (string.IsNullOrWhiteSpace(_emailSettings.NotificationTo))
        {
            return Task.CompletedTask;
        }

        var subject = $"New book added: {book.Title}";
        var body = $"<p>A new book was added.</p><ul><li>Title: {book.Title}</li><li>Author: {book.Author}</li><li>ISBN: {book.ISBN}</li><li>Published Year: {book.PublishedYear}</li></ul>";
        return _emailService.SendAsync(_emailSettings.NotificationTo, subject, body, true);
    }
}
