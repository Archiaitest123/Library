using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Domain.Interfaces;

public interface IBookLoanRepository : IRepository<BookLoan>
{
    Task<IEnumerable<BookLoan>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<BookLoan>> GetByBookIdAsync(Guid bookId);
    Task<IEnumerable<BookLoan>> GetActiveLoansAsync();
    Task<IEnumerable<BookLoan>> GetOverdueLoansAsync();
    Task<IEnumerable<BookLoan>> GetByStatusAsync(LoanStatus status);
    Task<BookLoan?> GetWithDetailsAsync(Guid id);
    Task<int> GetActiveLoanCountByCustomerAsync(Guid customerId);
}
