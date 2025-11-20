using DigiMoviezClone.Application.DTOs.Users;

namespace DigiMoviezClone.Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> RegisterAsync(UserRegisterDto dto);
        Task<UserResponseDto?> LoginAsync(UserLoginDto dto);
    }
    
}
