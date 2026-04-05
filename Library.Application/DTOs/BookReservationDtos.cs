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

public class ReservationQueueStatusDto
{
    public Guid BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public int TotalInQueue { get; set; }
    public int AvailableCopies { get; set; }
    public int TotalCopies { get; set; }
    public int EstimatedWaitDays { get; set; }
    public List<ReservationQueueEntryDto> QueueEntries { get; set; } = [];
}

public class ReservationQueueEntryDto
{
    public Guid ReservationId { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string MembershipType { get; set; } = string.Empty;
    public int Priority { get; set; }
    public int QueuePosition { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public ReservationStatus Status { get; set; }
}

public class ExpiredReservationsResultDto
{
    public int TotalProcessed { get; set; }
    public int NotificationsSent { get; set; }
    public List<Guid> ExpiredReservationIds { get; set; } = [];
}
