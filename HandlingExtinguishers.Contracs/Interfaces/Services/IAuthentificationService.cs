namespace HandlingExtinguishers.Contracts.Interfaces.Services;

#region Usings
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Authentication;
using ManagementFireEstinguisher.Dto.Users;
#endregion

public interface IAuthentificationService 
{
    public Task<OperationResult> Register( RegisterUserDto request );
    public Task<AuthenticationResponse> Login( LoginRequest request );
    public Task<AuthenticationResponse> RefreshToken( string token );
}
