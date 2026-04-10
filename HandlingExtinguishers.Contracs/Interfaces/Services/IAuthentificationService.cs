using HandlingExtinguisher.Dto.Users;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Authentication;
using ManagementFireEstinguisher.Dto.Users;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IAuthentificationService 
    {
        public Task<OperationResult> Register( RegisterUserDto request );
        public Task<AuthResponseDto> Login( LoginRequestDto request );
        public Task<AuthResponseDto> RefreshToken( string token );
    }
}
