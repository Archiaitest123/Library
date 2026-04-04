using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class BookReservation : BaseEntity
{
    public Guid BookId { get; set; }
    public Book Book { get; set; } = null!;

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public DateTime ReservationDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    public string? Notes { get; set; }
    public int QueuePosition { get; set; }
}
