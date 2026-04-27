namespace HandlingExtinguishers.Core.CommandServices;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.CommandServices;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Authentication;
using HandlingExtinguishers.Models.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
#endregion

public class AuthentificationService( UserManager<Users> userManager, IMapper mapper, JwtHandler jwtHandler ) : IAuthentificationCommandService
{
    private readonly UserManager<Users> userManager = userManager;
    private readonly IMapper mapper = mapper;
    private readonly JwtHandler jwtHandler = jwtHandler;

    public async Task<AuthenticationResponse> Login( LoginRequest request )
    {
        try
        {
            var user = await userManager.FindByEmailAsync( request.Email )
                ?? throw new AuthenticationException( HandlingExtinguisherResources.UserNotFound );

            if ( !await userManager.CheckPasswordAsync( user, request.Password ) )
            {
                await userManager.AccessFailedAsync( user );

                if ( await userManager.IsLockedOutAsync( user ) )
                {
                    throw new HandlingExceptions( HandlingExtinguisherResources.AccountBlocked );

                }

                throw new HandlingExceptions( HandlingExtinguisherResources.InvalidAuthentication );
            }

            var token = await jwtHandler.CreateToken( user );

            await userManager.ResetAccessFailedCountAsync( user );

            token.IsSuccess = true;

            return token;
        }
        catch ( Exception )
        {
            throw;
        }
    }

    public async Task<AuthenticationResponse> RefreshToken( string token )
    {
        try
        {
            var validateResult = jwtHandler.ValidateCurrentToken( token );
            var oldClams = jwtHandler.ValidatedClaimsCurrentToken( token );

            var handler = new JwtSecurityTokenHandler();

            var expiredToken = handler.ReadToken( token ) as JwtSecurityToken;

            var userId = expiredToken?.Claims.FirstOrDefault(type => type.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = await userManager.FindByIdAsync( userId! ) ?? throw new HandlingExceptions( HandlingExtinguisherResources.UserNotFound );
            var result = await jwtHandler.CreateToken( user );

            AuthenticationResponse response = new();

            if ( result is not null )
            {
                response.IsSuccess = true;
                response.Token = result.Token;
                response.Expiration = result.Expiration;
            }

            return response;
        }
        catch ( Exception )
        {
            throw;
        }
    }

    public async Task<OperationResult> Register( RegisterUserRequest request )
    {
        try
        {
            var response = new OperationResult();

            var user = mapper.Map<Users>( request );

            var result = await userManager.CreateAsync( user, request.Password );

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select( error => error.Description );
                response.IsSuccess = false;
                response.Errors = errors;

                return response;
            }

            response.IsSuccess = true;

            return response;
        }
        catch ( Exception )
        {
            throw;
        }
    }
}
