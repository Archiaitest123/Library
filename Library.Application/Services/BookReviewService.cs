using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class BookReviewService : IBookReviewService
{
    private readonly IBookReviewRepository _reviewRepository;
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;

    public BookReviewService(
        IBookReviewRepository reviewRepository,
        IBookRepository bookRepository,
        ICustomerRepository customerRepository)
    {
        _reviewRepository = reviewRepository;
        _bookRepository = bookRepository;
        _customerRepository = customerRepository;
    }

    public async Task<BookReviewDto?> GetByIdAsync(Guid id)
    {
        var review = await _reviewRepository.GetByIdAsync(id);
        return review?.ToDto();
    }

    public async Task<IEnumerable<BookReviewDto>> GetByBookIdAsync(Guid bookId)
    {
        var reviews = await _reviewRepository.GetApprovedReviewsByBookAsync(bookId);
        return reviews.Select(r => r.ToDto());
    }

    public async Task<IEnumerable<BookReviewDto>> GetByCustomerIdAsync(Guid customerId)
    {
        var reviews = await _reviewRepository.GetByCustomerIdAsync(customerId);
        return reviews.Select(r => r.ToDto());
    }

    public async Task<double> GetAverageRatingAsync(Guid bookId)
    {
        return await _reviewRepository.GetAverageRatingByBookAsync(bookId);
    }

    public async Task<BookReviewDto> CreateAsync(CreateBookReviewDto createDto)
    {
        if (!await _bookRepository.ExistsAsync(createDto.BookId))
            throw new NotFoundException(nameof(Domain.Entities.Book), createDto.BookId);

        if (!await _customerRepository.ExistsAsync(createDto.CustomerId))
            throw new NotFoundException(nameof(Domain.Entities.Customer), createDto.CustomerId);

        if (createDto.Rating < 1 || createDto.Rating > 5)
            throw new BadRequestException("Rating must be between 1 and 5.");

        var review = createDto.ToEntity();
        await _reviewRepository.AddAsync(review);
        return review.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateBookReviewDto updateDto)
    {
        var review = await _reviewRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookReview), id);

        if (updateDto.Rating < 1 || updateDto.Rating > 5)
            throw new BadRequestException("Rating must be between 1 and 5.");

        updateDto.UpdateEntity(review);
        await _reviewRepository.UpdateAsync(review);
    }

    public async Task ApproveReviewAsync(Guid id)
    {
        var review = await _reviewRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookReview), id);

        review.IsApproved = true;
        review.UpdatedAt = DateTime.UtcNow;
        await _reviewRepository.UpdateAsync(review);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _reviewRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.BookReview), id);

        await _reviewRepository.DeleteAsync(id);
    }
}
