namespace Library.Domain.Entities;

public class Publisher : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public int? FoundedYear { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Book> Books { get; set; } = [];
}
