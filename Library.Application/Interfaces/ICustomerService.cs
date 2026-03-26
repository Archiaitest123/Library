using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface ICustomerService
{
    Task<CustomerDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync();
    Task<CustomerDto> CreateAsync(CreateCustomerDto createDto);
    Task UpdateAsync(Guid id, UpdateCustomerDto updateDto);
    Task DeleteAsync(Guid id);
}
