using Library.Application.DTOs;
using Library.Domain.Enums;

namespace Library.Application.Interfaces;

public interface IBookLoanService
{
    Task<BookLoanDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<BookLoanDto>> GetAllAsync();
    Task<IEnumerable<BookLoanDto>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<BookLoanDto>> GetActiveLoansAsync();
    Task<IEnumerable<BookLoanDto>> GetOverdueLoansAsync();
    Task<IEnumerable<BookLoanDto>> GetByStatusAsync(LoanStatus status);
    Task<BookLoanDto> CreateAsync(CreateBookLoanDto createDto);
    Task<BookLoanDto> ReturnBookAsync(Guid id, ReturnBookLoanDto returnDto);
    Task<BookLoanDto> RenewLoanAsync(Guid id, RenewBookLoanDto renewDto);
    Task DeleteAsync(Guid id);
}
