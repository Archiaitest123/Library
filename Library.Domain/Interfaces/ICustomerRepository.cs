using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer?> GetByEmailAsync(string email);
    Task<Customer?> GetByMembershipNumberAsync(string membershipNumber);
    Task<IEnumerable<Customer>> GetActiveCustomersAsync();
}
