using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IBookRecommendationService
{
    Task<IEnumerable<BookRecommendationDto>> GetRecommendationsAsync(RecommendationRequestDto request);
    Task<CustomerReadingProfileDto> GetReadingProfileAsync(Guid customerId);
    Task<IEnumerable<BookRecommendationDto>> GetTrendingBooksAsync(int count = 10);
    Task<IEnumerable<BookRecommendationDto>> GetSimilarBooksAsync(Guid bookId, int count = 5);
}
