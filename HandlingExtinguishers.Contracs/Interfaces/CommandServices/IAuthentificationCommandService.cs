namespace HandlingExtinguishers.Contracts.Interfaces.CommandServices;

#region Usings
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Authentication;
#endregion

public interface IAuthentificationCommandService 
{
    public Task<OperationResult> Register( RegisterUserRequest request );

    public Task<AuthenticationResponse> Login( LoginRequest request );

    public Task<AuthenticationResponse> RefreshToken( string token );
}
