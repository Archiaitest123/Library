using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
    }

    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _dbSet.AnyAsync(u => u.Username == username);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _dbSet.AnyAsync(u => u.Email == email);
    }

    public async Task<IEnumerable<User>> GetActiveUsersAsync()
    {
        return await _dbSet.Where(u => u.IsActive).ToListAsync();
    }

    public async Task<IEnumerable<User>> GetByBranchIdAsync(Guid branchId)
    {
        return await _dbSet
            .Include(u => u.LibraryBranch)
            .Where(u => u.LibraryBranchId == branchId)
            .ToListAsync();
    }

    public async Task<User?> GetByEmployeeNumberAsync(string employeeNumber)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.EmployeeNumber == employeeNumber);
    }
}
