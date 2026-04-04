using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class LibraryBranchService : ILibraryBranchService
{
    private readonly ILibraryBranchRepository _branchRepository;

    public LibraryBranchService(ILibraryBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<LibraryBranchDto?> GetByIdAsync(Guid id)
    {
        var branch = await _branchRepository.GetByIdAsync(id);
        return branch?.ToDto();
    }

    public async Task<IEnumerable<LibraryBranchDto>> GetAllAsync()
    {
        var branches = await _branchRepository.GetAllAsync();
        return branches.Select(b => b.ToDto());
    }

    public async Task<IEnumerable<LibraryBranchDto>> GetActiveBranchesAsync()
    {
        var branches = await _branchRepository.GetActiveBranchesAsync();
        return branches.Select(b => b.ToDto());
    }

    public async Task<LibraryBranchDto> CreateAsync(CreateLibraryBranchDto createDto)
    {
        var branch = createDto.ToEntity();
        await _branchRepository.AddAsync(branch);
        return branch.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateLibraryBranchDto updateDto)
    {
        var branch = await _branchRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.LibraryBranch), id);

        updateDto.UpdateEntity(branch);
        await _branchRepository.UpdateAsync(branch);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _branchRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.LibraryBranch), id);

        await _branchRepository.DeleteAsync(id);
    }
}
