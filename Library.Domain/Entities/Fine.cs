using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class Fine : BaseEntity
{
    public Guid BookLoanId { get; set; }
    public BookLoan BookLoan { get; set; } = null!;

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public decimal Amount { get; set; }
    public string Reason { get; set; } = string.Empty;
    public FineStatus Status { get; set; } = FineStatus.Pending;
    public DateTime? PaidDate { get; set; }
    public string? PaymentMethod { get; set; }
}
