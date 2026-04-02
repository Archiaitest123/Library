using Library.Application.DTOs;
using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Application.Mappings;

public static class FineMappings
{
    public static FineDto ToDto(this Fine fine)
    {
        return new FineDto
        {
            Id = fine.Id,
            BookLoanId = fine.BookLoanId,
            CustomerId = fine.CustomerId,
            CustomerName = fine.Customer != null ? $"{fine.Customer.FirstName} {fine.Customer.LastName}" : string.Empty,
            BookTitle = fine.BookLoan?.Book?.Title ?? string.Empty,
            Amount = fine.Amount,
            Reason = fine.Reason,
            Status = fine.Status,
            PaidDate = fine.PaidDate,
            PaymentMethod = fine.PaymentMethod
        };
    }

    public static Fine ToEntity(this CreateFineDto dto)
    {
        return new Fine
        {
            Id = Guid.NewGuid(),
            BookLoanId = dto.BookLoanId,
            CustomerId = dto.CustomerId,
            Amount = dto.Amount,
            Reason = dto.Reason,
            Status = FineStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };
    }
}
