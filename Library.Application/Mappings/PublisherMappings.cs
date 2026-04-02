using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class PublisherMappings
{
    public static PublisherDto ToDto(this Publisher publisher)
    {
        return new PublisherDto
        {
            Id = publisher.Id,
            Name = publisher.Name,
            City = publisher.City,
            Country = publisher.Country,
            Phone = publisher.Phone,
            Email = publisher.Email,
            Website = publisher.Website,
            FoundedYear = publisher.FoundedYear,
            IsActive = publisher.IsActive,
            BookCount = publisher.Books?.Count ?? 0
        };
    }

    public static Publisher ToEntity(this CreatePublisherDto dto)
    {
        return new Publisher
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Address = dto.Address,
            City = dto.City,
            Country = dto.Country,
            Phone = dto.Phone,
            Email = dto.Email,
            Website = dto.Website,
            FoundedYear = dto.FoundedYear,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdatePublisherDto dto, Publisher publisher)
    {
        publisher.Name = dto.Name;
        publisher.Address = dto.Address;
        publisher.City = dto.City;
        publisher.Country = dto.Country;
        publisher.Phone = dto.Phone;
        publisher.Email = dto.Email;
        publisher.Website = dto.Website;
        publisher.FoundedYear = dto.FoundedYear;
        publisher.IsActive = dto.IsActive;
        publisher.UpdatedAt = DateTime.UtcNow;
    }
}
