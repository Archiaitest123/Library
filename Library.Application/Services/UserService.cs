using Library.Application.Common.Exceptions;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Application.Mappings;
using Library.Domain.Interfaces;

namespace Library.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto?> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user?.ToDto();
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(u => u.ToDto());
    }

    public async Task<IEnumerable<UserDto>> GetActiveUsersAsync()
    {
        var users = await _userRepository.GetActiveUsersAsync();
        return users.Select(u => u.ToDto());
    }

    public async Task<UserDto> CreateAsync(CreateUserDto createDto)
    {
        if (await _userRepository.UsernameExistsAsync(createDto.Username))
            throw new ConflictException($"Username '{createDto.Username}' is already taken.");

        if (await _userRepository.EmailExistsAsync(createDto.Email))
            throw new ConflictException($"Email '{createDto.Email}' is already registered.");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(createDto.Password, workFactor: 12);
        var user = createDto.ToEntity(passwordHash);
        await _userRepository.AddAsync(user);
        return user.ToDto();
    }

    public async Task UpdateAsync(Guid id, UpdateUserDto updateDto)
    {
        var user = await _userRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Domain.Entities.User), id);

        if (!string.Equals(user.Username, updateDto.Username, StringComparison.OrdinalIgnoreCase) &&
            await _userRepository.UsernameExistsAsync(updateDto.Username))
            throw new ConflictException($"Username '{updateDto.Username}' is already taken.");

        if (!string.Equals(user.Email, updateDto.Email, StringComparison.OrdinalIgnoreCase) &&
            await _userRepository.EmailExistsAsync(updateDto.Email))
            throw new ConflictException($"Email '{updateDto.Email}' is already registered.");

        updateDto.UpdateEntity(user);
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (!await _userRepository.ExistsAsync(id))
            throw new NotFoundException(nameof(Domain.Entities.User), id);

        await _userRepository.DeleteAsync(id);
    }
}
