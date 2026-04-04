using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Domain.Interfaces;

public interface IBookReservationRepository : IRepository<BookReservation>
{
    Task<IEnumerable<BookReservation>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<BookReservation>> GetByBookIdAsync(Guid bookId);
    Task<IEnumerable<BookReservation>> GetByStatusAsync(ReservationStatus status);
    Task<IEnumerable<BookReservation>> GetExpiredReservationsAsync();
    Task<BookReservation?> GetWithDetailsAsync(Guid id);
}
