using Library.Application.Common.Exceptions;
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
        var existing = await _staffRepository.GetByEmailAsync(createDto.Email);
        if (existing is not null)
            throw new ConflictException($"A staff member with email '{createDto.Email}' already exists.");

        var staff = createDto.ToEntity();
        await _staffRepository.AddAsync(staff);
        return staff.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateStaffDto updateDto)
    {
        var staff = await _staffRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.Staff), id);

        updateDto.UpdateEntity(staff);
        await _staffRepository.UpdateAsync(staff);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _staffRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.Staff), id);

        await _staffRepository.DeleteAsync(id);
    }
}
