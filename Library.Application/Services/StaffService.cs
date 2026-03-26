using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class StaffService : IStaffService
{
    private readonly IStaffRepository _staffRepository;

    public StaffService(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public async Task<StaffDto?> GetByIdAsync(Guid id)
    {
        var staff = await _staffRepository.GetByIdAsync(id);
        return staff?.ToDto();
    }

    public async Task<IEnumerable<StaffDto>> GetAllAsync()
    {
        var staffList = await _staffRepository.GetAllAsync();
        return staffList.Select(s => s.ToDto());
    }

    public async Task<IEnumerable<StaffDto>> GetActiveStaffAsync()
    {
        var staffList = await _staffRepository.GetActiveStaffAsync();
        return staffList.Select(s => s.ToDto());
    }

    public async Task<StaffDto> CreateAsync(CreateStaffDto createDto)
    {
        var staff = createDto.ToEntity();
        await _staffRepository.AddAsync(staff);
        return staff.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateStaffDto updateDto)
    {
        var staff = await _staffRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Staff with id {id} not found.");

        updateDto.UpdateEntity(staff);
        await _staffRepository.UpdateAsync(staff);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _staffRepository.DeleteAsync(id);
    }
}
