namespace HandlingExtinguishers.Contracts.Interfaces.Services;

#region Usings
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Authentication;
#endregion

public interface IAuthentificationService 
{
    public Task<OperationResult> Register( RegisterUserRequest request );

    public Task<AuthenticationResponse> Login( LoginRequest request );

    public Task<AuthenticationResponse> RefreshToken( string token );
}
