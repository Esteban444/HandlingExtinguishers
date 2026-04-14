namespace HandlingExtinguishers.Contracts.Interfaces.Services;

#region Usings
using HandlingExtinguisher.Dto.Users;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Authentication;
using ManagementFireEstinguisher.Dto.Users;
#endregion

public interface IAuthentificationService 
{
    public Task<OperationResult> Register( RegisterUserDto request );
    public Task<AuthResponseDto> Login( LoginRequestDto request );
    public Task<AuthResponseDto> RefreshToken( string token );
}
