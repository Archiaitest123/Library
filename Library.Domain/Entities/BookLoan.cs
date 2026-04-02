using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class BookLoan : BaseEntity
{
    public Guid BookId { get; set; }
    public Book Book { get; set; } = null!;

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public Guid? ProcessedByStaffId { get; set; }
    public Staff? ProcessedByStaff { get; set; }

    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public LoanStatus Status { get; set; } = LoanStatus.Active;
    public string? Notes { get; set; }
    public int RenewalCount { get; set; }
    public int MaxRenewals { get; set; } = 2;

    public ICollection<Fine> Fines { get; set; } = [];
}
