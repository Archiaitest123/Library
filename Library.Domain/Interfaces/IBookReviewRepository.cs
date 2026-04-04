using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IBookReviewRepository : IRepository<BookReview>
{
    Task<IEnumerable<BookReview>> GetByBookIdAsync(Guid bookId);
    Task<IEnumerable<BookReview>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<BookReview>> GetApprovedReviewsByBookAsync(Guid bookId);
    Task<double> GetAverageRatingByBookAsync(Guid bookId);
}
