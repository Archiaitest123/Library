using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public DateTime HireDate { get; set; }
    public bool IsActive { get; set; }
    public string? EmployeeNumber { get; set; }
    public Guid? LibraryBranchId { get; set; }
    public string? LibraryBranchName { get; set; }
}

public class CreateUserDto
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.Member;
    public decimal? Salary { get; set; }
    public DateTime HireDate { get; set; }
    public Guid? LibraryBranchId { get; set; }
}

public class UpdateUserDto
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public decimal? Salary { get; set; }
    public bool IsActive { get; set; }
    public Guid? LibraryBranchId { get; set; }
}
