using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class UserMappings
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Phone = user.Phone,
            Position = user.Position,
            Role = user.Role,
            HireDate = user.HireDate,
            IsActive = user.IsActive,
            EmployeeNumber = user.EmployeeNumber,
            LibraryBranchId = user.LibraryBranchId,
            LibraryBranchName = user.LibraryBranch?.Name
        };
    }

    public static User ToEntity(this CreateUserDto dto, string passwordHash)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = passwordHash,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Phone = dto.Phone,
            Position = dto.Position,
            Role = dto.Role,
            Salary = dto.Salary,
            HireDate = dto.HireDate,
            LibraryBranchId = dto.LibraryBranchId,
            EmployeeNumber = $"EMP-{Guid.NewGuid().ToString("N")[..6].ToUpper()}",
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateUserDto dto, User user)
    {
        user.Username = dto.Username;
        user.Email = dto.Email;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Phone = dto.Phone;
        user.Position = dto.Position;
        user.Role = dto.Role;
        user.Salary = dto.Salary;
        user.IsActive = dto.IsActive;
        user.LibraryBranchId = dto.LibraryBranchId;
        user.UpdatedAt = DateTime.UtcNow;
    }
}
