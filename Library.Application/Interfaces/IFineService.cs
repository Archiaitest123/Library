using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IFineService
{
    Task<FineDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<FineDto>> GetAllAsync();
    Task<IEnumerable<FineDto>> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<FineDto>> GetPendingFinesAsync();
    Task<decimal> GetTotalUnpaidByCustomerAsync(Guid customerId);
    Task<FineDto> CreateAsync(CreateFineDto createDto);
    Task<FineDto> PayFineAsync(Guid id, PayFineDto payDto);
    Task WaiveFineAsync(Guid id);
    Task DeleteAsync(Guid id);
}
