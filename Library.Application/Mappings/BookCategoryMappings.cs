using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class BookCategoryMappings
{
    public static BookCategoryDto ToDto(this BookCategory category)
    {
        return new BookCategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }

    public static BookCategory ToEntity(this CreateBookCategoryDto dto)
    {
        return new BookCategory
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description
        };
    }

    public static void UpdateEntity(this UpdateBookCategoryDto dto, BookCategory category)
    {
        category.Name = dto.Name;
        category.Description = dto.Description;
    }
}
