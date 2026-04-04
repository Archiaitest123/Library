using Library.Application.DTOs;
using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Application.Mappings;

public static class BookReservationMappings
{
    public static BookReservationDto ToDto(this BookReservation reservation)
    {
        return new BookReservationDto
        {
            Id = reservation.Id,
            BookId = reservation.BookId,
            BookTitle = reservation.Book?.Title ?? string.Empty,
            CustomerId = reservation.CustomerId,
            CustomerName = reservation.Customer != null ? $"{reservation.Customer.FirstName} {reservation.Customer.LastName}" : string.Empty,
            ReservationDate = reservation.ReservationDate,
            ExpiryDate = reservation.ExpiryDate,
            Status = reservation.Status,
            QueuePosition = reservation.QueuePosition
        };
    }

    public static BookReservation ToEntity(this CreateBookReservationDto dto)
    {
        return new BookReservation
        {
            Id = Guid.NewGuid(),
            BookId = dto.BookId,
            CustomerId = dto.CustomerId,
            ReservationDate = DateTime.UtcNow,
            ExpiryDate = DateTime.UtcNow.AddDays(3),
            Status = ReservationStatus.Pending,
            Notes = dto.Notes,
            CreatedAt = DateTime.UtcNow
        };
    }
}
