namespace Library.Domain.Entities;

public class BookReview : BaseEntity
{
    public Guid BookId { get; set; }
    public Book Book { get; set; } = null!;

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public int Rating { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public bool IsApproved { get; set; }
}
