using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IUserService
{
    Task<UserDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<IEnumerable<UserDto>> GetActiveUsersAsync();
    Task<UserDto> CreateAsync(CreateUserDto createDto);
    Task UpdateAsync(Guid id, UpdateUserDto updateDto);
    Task DeleteAsync(Guid id);
}
