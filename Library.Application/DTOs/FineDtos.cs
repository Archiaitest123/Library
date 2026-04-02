using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class FineDto
{
    public Guid Id { get; set; }
    public Guid BookLoanId { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string BookTitle { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Reason { get; set; } = string.Empty;
    public FineStatus Status { get; set; }
    public DateTime? PaidDate { get; set; }
    public string? PaymentMethod { get; set; }
}

public class CreateFineDto
{
    public Guid BookLoanId { get; set; }
    public Guid CustomerId { get; set; }
    public decimal Amount { get; set; }
    public string Reason { get; set; } = string.Empty;
}

public class PayFineDto
{
    public string PaymentMethod { get; set; } = string.Empty;
}
