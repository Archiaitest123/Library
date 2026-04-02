using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IBookReviewService
{
    Task<BookReviewDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<BookReviewDto>> GetByBookIdAsync(Guid bookId);
    Task<IEnumerable<BookReviewDto>> GetByCustomerIdAsync(Guid customerId);
    Task<double> GetAverageRatingAsync(Guid bookId);
    Task<BookReviewDto> CreateAsync(CreateBookReviewDto createDto);
    Task UpdateAsync(Guid id, UpdateBookReviewDto updateDto);
    Task ApproveReviewAsync(Guid id);
    Task DeleteAsync(Guid id);
}
