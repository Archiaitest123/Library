using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class BookReservationDto
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public DateTime ReservationDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public ReservationStatus Status { get; set; }
    public int QueuePosition { get; set; }
}

public class CreateBookReservationDto
{
    public Guid BookId { get; set; }
    public Guid CustomerId { get; set; }
    public string? Notes { get; set; }
}
