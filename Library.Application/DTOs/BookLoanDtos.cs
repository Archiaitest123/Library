using Library.Domain.Enums;

namespace Library.Application.DTOs;

public class BookLoanDto
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public string BookISBN { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public Guid? ProcessedByUserId { get; set; }
    public string? ProcessedByUserName { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public LoanStatus Status { get; set; }
    public string? Notes { get; set; }
    public int RenewalCount { get; set; }
    public int MaxRenewals { get; set; }
    public bool IsOverdue { get; set; }
}

public class CreateBookLoanDto
{
    public Guid BookId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid? ProcessedByUserId { get; set; }
    public int LoanDurationDays { get; set; } = 14;
    public string? Notes { get; set; }
}

public class ReturnBookLoanDto
{
    public string? Notes { get; set; }
}

public class RenewBookLoanDto
{
    public int AdditionalDays { get; set; } = 14;
}
