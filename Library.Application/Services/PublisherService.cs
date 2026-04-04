using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;

    public PublisherService(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    public async Task<PublisherDto?> GetByIdAsync(Guid id)
    {
        var publisher = await _publisherRepository.GetWithBooksAsync(id);
        return publisher?.ToDto();
    }

    public async Task<IEnumerable<PublisherDto>> GetAllAsync()
    {
        var publishers = await _publisherRepository.GetAllAsync();
        return publishers.Select(p => p.ToDto());
    }

    public async Task<IEnumerable<PublisherDto>> GetActivePublishersAsync()
    {
        var publishers = await _publisherRepository.GetActivePublishersAsync();
        return publishers.Select(p => p.ToDto());
    }

    public async Task<PublisherDto> CreateAsync(CreatePublisherDto createDto)
    {
        var existing = await _publisherRepository.GetByNameAsync(createDto.Name);
        if (existing is not null)
            throw new ConflictException($"Publisher with name '{createDto.Name}' already exists.");

        var publisher = createDto.ToEntity();
        await _publisherRepository.AddAsync(publisher);
        return publisher.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdatePublisherDto updateDto)
    {
        var publisher = await _publisherRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.Publisher), id);

        updateDto.UpdateEntity(publisher);
        await _publisherRepository.UpdateAsync(publisher);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _publisherRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.Publisher), id);

        await _publisherRepository.DeleteAsync(id);
    }
}
