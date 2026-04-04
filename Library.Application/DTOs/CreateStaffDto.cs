using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class CreateStaffDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public StaffRole Role { get; set; } = StaffRole.Librarian;
    public decimal? Salary { get; set; }
    public DateTime HireDate { get; set; }
    public Guid? LibraryBranchId { get; set; }
}
