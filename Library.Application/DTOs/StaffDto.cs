using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class StaffDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public StaffRole Role { get; set; }
    public DateTime HireDate { get; set; }
    public bool IsActive { get; set; }
    public string? EmployeeNumber { get; set; }
    public Guid? LibraryBranchId { get; set; }
    public string? LibraryBranchName { get; set; }
}
