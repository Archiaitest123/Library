using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IPublisherService
{
    Task<PublisherDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<PublisherDto>> GetAllAsync();
    Task<IEnumerable<PublisherDto>> GetActivePublishersAsync();
    Task<PublisherDto> CreateAsync(CreatePublisherDto createDto);
    Task UpdateAsync(Guid id, UpdatePublisherDto updateDto);
    Task DeleteAsync(Guid id);
}
