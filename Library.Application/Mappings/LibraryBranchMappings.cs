using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class LibraryBranchMappings
{
    public static LibraryBranchDto ToDto(this LibraryBranch branch)
    {
        return new LibraryBranchDto
        {
            Id = branch.Id,
            Name = branch.Name,
            Address = branch.Address,
            City = branch.City,
            Phone = branch.Phone,
            Email = branch.Email,
            Description = branch.Description,
            OpeningTime = branch.OpeningTime,
            ClosingTime = branch.ClosingTime,
            IsActive = branch.IsActive,
            StaffCount = branch.Staff?.Count ?? 0,
            BookCount = branch.Books?.Count ?? 0
        };
    }

    public static LibraryBranch ToEntity(this CreateLibraryBranchDto dto)
    {
        return new LibraryBranch
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Address = dto.Address,
            City = dto.City,
            PostalCode = dto.PostalCode,
            Phone = dto.Phone,
            Email = dto.Email,
            Description = dto.Description,
            OpeningTime = dto.OpeningTime,
            ClosingTime = dto.ClosingTime,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateLibraryBranchDto dto, LibraryBranch branch)
    {
        branch.Name = dto.Name;
        branch.Address = dto.Address;
        branch.City = dto.City;
        branch.PostalCode = dto.PostalCode;
        branch.Phone = dto.Phone;
        branch.Email = dto.Email;
        branch.Description = dto.Description;
        branch.OpeningTime = dto.OpeningTime;
        branch.ClosingTime = dto.ClosingTime;
        branch.IsActive = dto.IsActive;
        branch.Latitude = dto.Latitude;
        branch.Longitude = dto.Longitude;
        branch.UpdatedAt = DateTime.UtcNow;
    }
}
