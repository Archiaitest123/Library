using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class StaffRepository : BaseRepository<Staff>, IStaffRepository
{
    public StaffRepository(LibraryDbContext context) : base(context) { }

    public async Task<Staff?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(s => s.Email == email);
    }

    public async Task<IEnumerable<Staff>> GetActiveStaffAsync()
    {
        return await _dbSet.Where(s => s.IsActive).ToListAsync();
    }

    public async Task<IEnumerable<Staff>> GetByBranchIdAsync(Guid branchId)
    {
        return await _dbSet
            .Include(s => s.LibraryBranch)
            .Where(s => s.LibraryBranchId == branchId)
            .ToListAsync();
    }

    public async Task<Staff?> GetByEmployeeNumberAsync(string employeeNumber)
    {
        return await _dbSet.FirstOrDefaultAsync(s => s.EmployeeNumber == employeeNumber);
    }
}
