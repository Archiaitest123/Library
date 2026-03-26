using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class BookMappings
{
    public static BookDto ToDto(this Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            ISBN = book.ISBN,
            PublishedYear = book.PublishedYear,
            IsAvailable = book.IsAvailable,
            BookCategoryId = book.BookCategoryId,
            BookCategoryName = book.BookCategory?.Name
        };
    }

    public static Book ToEntity(this CreateBookDto dto)
    {
        return new Book
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Author = dto.Author,
            ISBN = dto.ISBN,
            PublishedYear = dto.PublishedYear,
            IsAvailable = true,
            BookCategoryId = dto.BookCategoryId
        };
    }

    public static void UpdateEntity(this UpdateBookDto dto, Book book)
    {
        book.Title = dto.Title;
        book.Author = dto.Author;
        book.ISBN = dto.ISBN;
        book.PublishedYear = dto.PublishedYear;
        book.IsAvailable = dto.IsAvailable;
        book.BookCategoryId = dto.BookCategoryId;
    }
}
