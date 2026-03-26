using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class StaffRepository : IStaffRepository
{
    private readonly LibraryDbContext _context;

    public StaffRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<Staff?> GetByIdAsync(Guid id)
    {
        return await _context.Staff.FindAsync(id);
    }

    public async Task<IEnumerable<Staff>> GetAllAsync()
    {
        return await _context.Staff.ToListAsync();
    }

    public async Task<Staff?> GetByEmailAsync(string email)
    {
        return await _context.Staff
            .FirstOrDefaultAsync(s => s.Email == email);
    }

    public async Task<IEnumerable<Staff>> GetActiveStaffAsync()
    {
        return await _context.Staff
            .Where(s => s.IsActive)
            .ToListAsync();
    }

    public async Task AddAsync(Staff entity)
    {
        await _context.Staff.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Staff entity)
    {
        _context.Staff.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var staff = await _context.Staff.FindAsync(id);
        if (staff is not null)
        {
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
        }
    }
}
