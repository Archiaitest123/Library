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
            ISBN = book.ISBN,
            Description = book.Description,
            PublishedYear = book.PublishedYear,
            PageCount = book.PageCount,
            Language = book.Language,
            IsAvailable = book.IsAvailable,
            TotalCopies = book.TotalCopies,
            AvailableCopies = book.AvailableCopies,
            Condition = book.Condition,
            Price = book.Price,
            AuthorId = book.AuthorId,
            AuthorName = book.Author != null ? $"{book.Author.FirstName} {book.Author.LastName}" : string.Empty,
            PublisherId = book.PublisherId,
            PublisherName = book.Publisher?.Name,
            BookCategoryId = book.BookCategoryId,
            BookCategoryName = book.BookCategory?.Name,
            LibraryBranchId = book.LibraryBranchId,
            LibraryBranchName = book.LibraryBranch?.Name
        };
    }

    public static Book ToEntity(this CreateBookDto dto)
    {
        return new Book
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            ISBN = dto.ISBN,
            Description = dto.Description,
            PublishedYear = dto.PublishedYear,
            PageCount = dto.PageCount,
            Language = dto.Language,
            IsAvailable = true,
            TotalCopies = dto.TotalCopies,
            AvailableCopies = dto.TotalCopies,
            AuthorId = dto.AuthorId,
            PublisherId = dto.PublisherId,
            BookCategoryId = dto.BookCategoryId,
            LibraryBranchId = dto.LibraryBranchId,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateBookDto dto, Book book)
    {
        book.Title = dto.Title;
        book.ISBN = dto.ISBN;
        book.Description = dto.Description;
        book.PublishedYear = dto.PublishedYear;
        book.PageCount = dto.PageCount;
        book.Language = dto.Language;
        book.IsAvailable = dto.IsAvailable;
        book.TotalCopies = dto.TotalCopies;
        book.AvailableCopies = dto.AvailableCopies;
        book.Condition = dto.Condition;
        book.Price = dto.Price;
        book.AuthorId = dto.AuthorId;
        book.PublisherId = dto.PublisherId;
        book.BookCategoryId = dto.BookCategoryId;
        book.LibraryBranchId = dto.LibraryBranchId;
        book.UpdatedAt = DateTime.UtcNow;
    }
}
