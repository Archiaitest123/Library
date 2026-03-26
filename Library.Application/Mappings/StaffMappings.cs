using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class StaffMappings
{
    public static StaffDto ToDto(this Staff staff)
    {
        return new StaffDto
        {
            Id = staff.Id,
            FirstName = staff.FirstName,
            LastName = staff.LastName,
            Email = staff.Email,
            Phone = staff.Phone,
            Position = staff.Position,
            HireDate = staff.HireDate,
            IsActive = staff.IsActive
        };
    }

    public static Staff ToEntity(this CreateStaffDto dto)
    {
        return new Staff
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            Position = dto.Position,
            HireDate = dto.HireDate,
            IsActive = true
        };
    }

    public static void UpdateEntity(this UpdateStaffDto dto, Staff staff)
    {
        staff.FirstName = dto.FirstName;
        staff.LastName = dto.LastName;
        staff.Email = dto.Email;
        staff.Phone = dto.Phone;
        staff.Position = dto.Position;
        staff.IsActive = dto.IsActive;
    }
}
