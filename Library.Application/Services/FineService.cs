using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Enums;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class FineService : IFineService
{
    private readonly IFineRepository _fineRepository;

    public FineService(IFineRepository fineRepository)
    {
        _fineRepository = fineRepository;
    }

    public async Task<FineDto?> GetByIdAsync(Guid id)
    {
        var fine = await _fineRepository.GetByIdAsync(id);
        return fine?.ToDto();
    }

    public async Task<IEnumerable<FineDto>> GetAllAsync()
    {
        var fines = await _fineRepository.GetAllAsync();
        return fines.Select(f => f.ToDto());
    }

    public async Task<IEnumerable<FineDto>> GetByCustomerIdAsync(Guid customerId)
    {
        var fines = await _fineRepository.GetByCustomerIdAsync(customerId);
        return fines.Select(f => f.ToDto());
    }

    public async Task<IEnumerable<FineDto>> GetPendingFinesAsync()
    {
        var fines = await _fineRepository.GetPendingFinesAsync();
        return fines.Select(f => f.ToDto());
    }

    public async Task<decimal> GetTotalUnpaidByCustomerAsync(Guid customerId)
    {
        return await _fineRepository.GetTotalUnpaidFinesByCustomerAsync(customerId);
    }

    public async Task<FineDto> CreateAsync(CreateFineDto createDto)
    {
        var fine = createDto.ToEntity();
        await _fineRepository.AddAsync(fine);
        return fine.ToDto();
    }

    public async Task<FineDto> PayFineAsync(Guid id, PayFineDto payDto)
    {
        var fine = await _fineRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.Fine), id);

        if (fine.Status == FineStatus.Paid)
            throw new BadRequestException("This fine has already been paid.");

        fine.Status = FineStatus.Paid;
        fine.PaidDate = DateTime.UtcNow;
        fine.PaymentMethod = payDto.PaymentMethod;
        fine.UpdatedAt = DateTime.UtcNow;
        await _fineRepository.UpdateAsync(fine);

        return fine.ToDto();
    }

    public async Task WaiveFineAsync(Guid id)
    {
        var fine = await _fineRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.Fine), id);

        fine.Status = FineStatus.Waived;
        fine.UpdatedAt = DateTime.UtcNow;
        await _fineRepository.UpdateAsync(fine);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _fineRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.Fine), id);

        await _fineRepository.DeleteAsync(id);
    }
}
