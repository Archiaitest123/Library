using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class BookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int PageCount { get; set; }
    public string Language { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public BookCondition Condition { get; set; }
    public decimal? Price { get; set; }
    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public Guid? PublisherId { get; set; }
    public string? PublisherName { get; set; }
    public Guid? BookCategoryId { get; set; }
    public string? BookCategoryName { get; set; }
    public Guid? LibraryBranchId { get; set; }
    public string? LibraryBranchName { get; set; }
}
