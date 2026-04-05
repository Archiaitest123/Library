using Library.Application.DTOs;
using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Application.Mappings;

public static class BookLoanMappings
{
    public static BookLoanDto ToDto(this BookLoan loan)
    {
        return new BookLoanDto
        {
            Id = loan.Id,
            BookId = loan.BookId,
            BookTitle = loan.Book?.Title ?? string.Empty,
            BookISBN = loan.Book?.ISBN ?? string.Empty,
            CustomerId = loan.CustomerId,
            CustomerName = loan.Customer != null ? $"{loan.Customer.FirstName} {loan.Customer.LastName}" : string.Empty,
            ProcessedByUserId = loan.ProcessedByUserId,
            ProcessedByUserName = loan.ProcessedByUser != null ? $"{loan.ProcessedByUser.FirstName} {loan.ProcessedByUser.LastName}" : null,
            LoanDate = loan.LoanDate,
            DueDate = loan.DueDate,
            ReturnDate = loan.ReturnDate,
            Status = loan.Status,
            Notes = loan.Notes,
            RenewalCount = loan.RenewalCount,
            MaxRenewals = loan.MaxRenewals,
            IsOverdue = loan.Status == LoanStatus.Active && loan.DueDate < DateTime.UtcNow
        };
    }

    public static BookLoan ToEntity(this CreateBookLoanDto dto)
    {
        return new BookLoan
        {
            Id = Guid.NewGuid(),
            BookId = dto.BookId,
            CustomerId = dto.CustomerId,
            ProcessedByUserId = dto.ProcessedByUserId,
            LoanDate = DateTime.UtcNow,
            DueDate = DateTime.UtcNow.AddDays(dto.LoanDurationDays),
            Status = LoanStatus.Active,
            Notes = dto.Notes,
            RenewalCount = 0,
            MaxRenewals = 2,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static BookLoan ToEntity(this CreateBookLoanDto dto, int loanDurationDays, int maxRenewals)
    {
        return new BookLoan
        {
            Id = Guid.NewGuid(),
            BookId = dto.BookId,
            CustomerId = dto.CustomerId,
            ProcessedByUserId = dto.ProcessedByUserId,
            LoanDate = DateTime.UtcNow,
            DueDate = DateTime.UtcNow.AddDays(loanDurationDays),
            Status = LoanStatus.Active,
            Notes = dto.Notes,
            RenewalCount = 0,
            MaxRenewals = maxRenewals,
            CreatedAt = DateTime.UtcNow
        };
    }
}
