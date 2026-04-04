using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Enums;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class BookReservationService : IBookReservationService
{
    private readonly IBookReservationRepository _reservationRepository;
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;

    public BookReservationService(
        IBookReservationRepository reservationRepository,
        IBookRepository bookRepository,
        ICustomerRepository customerRepository)
    {
        _reservationRepository = reservationRepository;
        _bookRepository = bookRepository;
        _customerRepository = customerRepository;
    }

    public async Task<BookReservationDto?> GetByIdAsync(Guid id)
    {
        var reservation = await _reservationRepository.GetWithDetailsAsync(id);
        return reservation?.ToDto();
    }

    public async Task<IEnumerable<BookReservationDto>> GetAllAsync()
    {
        var reservations = await _reservationRepository.GetAllAsync();
        return reservations.Select(r => r.ToDto());
    }

    public async Task<IEnumerable<BookReservationDto>> GetByCustomerIdAsync(Guid customerId)
    {
        var reservations = await _reservationRepository.GetByCustomerIdAsync(customerId);
        return reservations.Select(r => r.ToDto());
    }

    public async Task<IEnumerable<BookReservationDto>> GetByBookIdAsync(Guid bookId)
    {
        var reservations = await _reservationRepository.GetByBookIdAsync(bookId);
        return reservations.Select(r => r.ToDto());
    }

    public async Task<BookReservationDto> CreateAsync(CreateBookReservationDto createDto)
    {
        if (!await _bookRepository.ExistsAsync(createDto.BookId))
            throw new NotFoundException(nameof(Domain.Entities.Book), createDto.BookId);

        var customer = await _customerRepository.GetByIdAsync(createDto.CustomerId)
            ?? throw new NotFoundException(nameof(Domain.Entities.Customer), createDto.CustomerId);

        if (!customer.IsActive)
            throw new BadRequestException("Customer membership is not active.");

        var existingReservations = await _reservationRepository.GetByBookIdAsync(createDto.BookId);
        var queuePosition = existingReservations.Count(r => r.Status == ReservationStatus.Pending) + 1;

        var reservation = createDto.ToEntity();
        reservation.QueuePosition = queuePosition;
        await _reservationRepository.AddAsync(reservation);

        return reservation.ToDto();
    }

    public async Task CancelReservationAsync(Guid id)
    {
        var reservation = await _reservationRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookReservation), id);

        reservation.Status = ReservationStatus.Cancelled;
        reservation.UpdatedAt = DateTime.UtcNow;
        await _reservationRepository.UpdateAsync(reservation);
    }

    public async Task FulfillReservationAsync(Guid id)
    {
        var reservation = await _reservationRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.BookReservation), id);

        reservation.Status = ReservationStatus.Fulfilled;
        reservation.UpdatedAt = DateTime.UtcNow;
        await _reservationRepository.UpdateAsync(reservation);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _reservationRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.BookReservation), id);

        await _reservationRepository.DeleteAsync(id);
    }
}
