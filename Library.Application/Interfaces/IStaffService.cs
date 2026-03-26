using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IStaffService
{
    Task<StaffDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<StaffDto>> GetAllAsync();
    Task<IEnumerable<StaffDto>> GetActiveStaffAsync();
    Task<StaffDto> CreateAsync(CreateStaffDto createDto);
    Task UpdateAsync(Guid id, UpdateStaffDto updateDto);
    Task DeleteAsync(Guid id);
}
