using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IBookReservationService
{
    Task<BookReservationDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<BookReservationDto>> GetAllAsync();
    Task<IEnumerable<BookReservationDto>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<BookReservationDto>> GetByBookIdAsync(Guid bookId);
    Task<BookReservationDto> CreateAsync(CreateBookReservationDto createDto);
    Task CancelReservationAsync(Guid id);
    Task FulfillReservationAsync(Guid id);
    Task DeleteAsync(Guid id);
}
