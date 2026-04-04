using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer?> GetByEmailAsync(string email);
    Task<Customer?> GetByMembershipNumberAsync(string membershipNumber);
    Task<IEnumerable<Customer>> GetActiveCustomersAsync();
    Task<Customer?> GetWithLoansAsync(Guid id);
    Task<Customer?> GetWithReservationsAsync(Guid id);
    Task<IEnumerable<Customer>> SearchAsync(string searchTerm);
}
