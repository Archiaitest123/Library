using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IStaffRepository : IRepository<Staff>
{
    Task<Staff?> GetByEmailAsync(string email);
    Task<IEnumerable<Staff>> GetActiveStaffAsync();
    Task<IEnumerable<Staff>> GetByBranchIdAsync(Guid branchId);
    Task<Staff?> GetByEmployeeNumberAsync(string employeeNumber);
}
