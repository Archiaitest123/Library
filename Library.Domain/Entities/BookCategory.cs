namespace Library.Domain.Entities;

public class BookCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? IconUrl { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; } = true;

    public Guid? ParentCategoryId { get; set; }
    public BookCategory? ParentCategory { get; set; }

    public ICollection<BookCategory> SubCategories { get; set; } = [];
    public ICollection<Book> Books { get; set; } = [];
}
