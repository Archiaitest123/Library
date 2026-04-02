using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class Staff : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public StaffRole Role { get; set; } = StaffRole.Librarian;
    public decimal? Salary { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime? TerminationDate { get; set; }
    public bool IsActive { get; set; } = true;
    public string? EmployeeNumber { get; set; }

    public Guid? LibraryBranchId { get; set; }
    public LibraryBranch? LibraryBranch { get; set; }

    public ICollection<BookLoan> ProcessedLoans { get; set; } = [];
}
