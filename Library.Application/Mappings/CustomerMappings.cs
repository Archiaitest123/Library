using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class CustomerMappings
{
    public static CustomerDto ToDto(this Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Phone = customer.Phone,
            Address = customer.Address,
            City = customer.City,
            MembershipNumber = customer.MembershipNumber,
            MembershipType = customer.MembershipType,
            RegisteredDate = customer.RegisteredDate,
            MembershipExpiryDate = customer.MembershipExpiryDate,
            IsActive = customer.IsActive,
            MaxBooksAllowed = customer.MaxBooksAllowed
        };
    }

    public static Customer ToEntity(this CreateCustomerDto dto)
    {
        return new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            Address = dto.Address,
            City = dto.City,
            PostalCode = dto.PostalCode,
            MembershipType = dto.MembershipType,
            DateOfBirth = dto.DateOfBirth,
            MembershipNumber = $"LIB-{Guid.NewGuid().ToString("N")[..8].ToUpper()}",
            RegisteredDate = DateTime.UtcNow,
            MembershipExpiryDate = DateTime.UtcNow.AddYears(1),
            IsActive = true,
            MaxBooksAllowed = dto.MembershipType switch
            {
                Domain.Enums.MembershipType.Premium => 10,
                Domain.Enums.MembershipType.Standard => 7,
                Domain.Enums.MembershipType.Student => 5,
                Domain.Enums.MembershipType.Senior => 7,
                _ => 5
            },
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateCustomerDto dto, Customer customer)
    {
        customer.FirstName = dto.FirstName;
        customer.LastName = dto.LastName;
        customer.Email = dto.Email;
        customer.Phone = dto.Phone;
        customer.Address = dto.Address;
        customer.City = dto.City;
        customer.PostalCode = dto.PostalCode;
        customer.MembershipType = dto.MembershipType;
        customer.IsActive = dto.IsActive;
        customer.UpdatedAt = DateTime.UtcNow;
    }
}
