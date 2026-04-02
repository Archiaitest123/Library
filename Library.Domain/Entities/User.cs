using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.Member;
    public decimal? Salary { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime? TerminationDate { get; set; }
    public bool IsActive { get; set; } = true;
    public string? EmployeeNumber { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }

    public Guid? LibraryBranchId { get; set; }
    public LibraryBranch? LibraryBranch { get; set; }

    public ICollection<BookLoan> ProcessedLoans { get; set; } = [];
}
