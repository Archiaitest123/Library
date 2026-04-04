namespace Library.Domain.Entities;

public class Author : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Biography { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? Nationality { get; set; }
    public string? Website { get; set; }
    public string? PhotoUrl { get; set; }

    public ICollection<Book> Books { get; set; } = [];
}
