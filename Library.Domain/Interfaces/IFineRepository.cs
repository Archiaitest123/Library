using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Domain.Interfaces;

public interface IFineRepository : IRepository<Fine>
{
    Task<IEnumerable<Fine>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<Fine>> GetByStatusAsync(FineStatus status);
    Task<IEnumerable<Fine>> GetPendingFinesAsync();
    Task<decimal> GetTotalUnpaidFinesByCustomerAsync(Guid customerId);
}
