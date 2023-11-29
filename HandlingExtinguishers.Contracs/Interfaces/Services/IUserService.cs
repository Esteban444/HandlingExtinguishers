using HamdlingExtinguisher.Dto.Users;
using HandlingExtinguisher.Dto.Users;
using ManagementFireEstinguisher.Dto.Users;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IUserService
    {
        public Task<RegisterResponseDto> Register(RegisterUserDto request);
        public Task<AuthResponseDto> Login(LoginRequestDto request);
        public Task<AuthResponseDto> RefreshToken(string token);
    }
}
