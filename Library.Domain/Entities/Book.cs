using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int PageCount { get; set; }
    public string Language { get; set; } = "Turkish";
    public bool IsAvailable { get; set; } = true;
    public int TotalCopies { get; set; } = 1;
    public int AvailableCopies { get; set; } = 1;
    public BookCondition Condition { get; set; } = BookCondition.New;
    public string? CoverImageUrl { get; set; }
    public decimal? Price { get; set; }

    public Guid AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    public Guid? PublisherId { get; set; }
    public Publisher? Publisher { get; set; }

    public Guid? BookCategoryId { get; set; }
    public BookCategory? BookCategory { get; set; }

    public Guid? LibraryBranchId { get; set; }
    public LibraryBranch? LibraryBranch { get; set; }

    public ICollection<BookLoan> BookLoans { get; set; } = [];
    public ICollection<BookReservation> BookReservations { get; set; } = [];
    public ICollection<BookReview> BookReviews { get; set; } = [];
}
