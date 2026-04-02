using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class AuthorMappings
{
    public static AuthorDto ToDto(this Author author)
    {
        return new AuthorDto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            Biography = author.Biography,
            BirthDate = author.BirthDate,
            Nationality = author.Nationality,
            Website = author.Website,
            BookCount = author.Books?.Count ?? 0
        };
    }

    public static Author ToEntity(this CreateAuthorDto dto)
    {
        return new Author
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Biography = dto.Biography,
            BirthDate = dto.BirthDate,
            DeathDate = dto.DeathDate,
            Nationality = dto.Nationality,
            Website = dto.Website,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateAuthorDto dto, Author author)
    {
        author.FirstName = dto.FirstName;
        author.LastName = dto.LastName;
        author.Biography = dto.Biography;
        author.BirthDate = dto.BirthDate;
        author.DeathDate = dto.DeathDate;
        author.Nationality = dto.Nationality;
        author.Website = dto.Website;
        author.UpdatedAt = DateTime.UtcNow;
    }
}
