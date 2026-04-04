using Library.Application.DTOs;

namespace Library.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
    Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
    Task RevokeRefreshTokenAsync(Guid userId);
    Task ChangePasswordAsync(Guid userId, ChangePasswordDto changePasswordDto);
    Task<UserInfoDto?> GetCurrentUserAsync(Guid userId);
}
