using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings;

public static class BookReviewMappings
{
    public static BookReviewDto ToDto(this BookReview review)
    {
        return new BookReviewDto
        {
            Id = review.Id,
            BookId = review.BookId,
            BookTitle = review.Book?.Title ?? string.Empty,
            CustomerId = review.CustomerId,
            CustomerName = review.Customer != null ? $"{review.Customer.FirstName} {review.Customer.LastName}" : string.Empty,
            Rating = review.Rating,
            Title = review.Title,
            Comment = review.Comment,
            IsApproved = review.IsApproved,
            CreatedAt = review.CreatedAt
        };
    }

    public static BookReview ToEntity(this CreateBookReviewDto dto)
    {
        return new BookReview
        {
            Id = Guid.NewGuid(),
            BookId = dto.BookId,
            CustomerId = dto.CustomerId,
            Rating = dto.Rating,
            Title = dto.Title,
            Comment = dto.Comment,
            IsApproved = false,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateBookReviewDto dto, BookReview review)
    {
        review.Rating = dto.Rating;
        review.Title = dto.Title;
        review.Comment = dto.Comment;
        review.UpdatedAt = DateTime.UtcNow;
    }
}
