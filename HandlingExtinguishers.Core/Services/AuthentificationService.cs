using AutoMapper;
using HandlingExtinguisher.Dto;
using HandlingExtinguisher.Dto.Users;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models.Models;
using ManagementFireEstinguisher.Dto.Users;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HandlingExtinguishers.Core.Localization;
using System.Security.Authentication;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Helpers;

namespace HandlingExtinguishers.Core.Services
{
    public class AuthentificationService( UserManager<Users> userManager, IMapper mapper, JwtHandler jwtHandler, ILocalizationService localizationService ) : IAuthentificationService
    {
        private readonly UserManager<Users> userManager = userManager;
        private readonly IMapper mapper = mapper;
        private readonly JwtHandler jwtHandler = jwtHandler;
        private readonly ILocalizationService localizationService = localizationService;

        public async Task<AuthResponseDto> Login( LoginRequestDto request )
        {
            try
            {
                var user = await userManager.FindByEmailAsync(request.Email)
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

                return new AuthResponseDto { IsSuccess = true, Token = token };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AuthResponseDto> RefreshToken( string token )
        {
            try
            {
                var validateResult = jwtHandler.ValidateCurrentToken( token );
                var oldClams = jwtHandler.ValidatedClaimsCurrentToken( token );

                var handler = new JwtSecurityTokenHandler();

                var expiredToken = handler.ReadToken( token ) as JwtSecurityToken;
                var userId = expiredToken?.Claims.FirstOrDefault( c => c.Type == ClaimTypes.NameIdentifier )?.Value;

                var user = await userManager.FindByIdAsync(userId!) ?? throw new HandlingExceptions( HandlingExtinguisherResources.UserNotFound );

                var result = await jwtHandler.CreateToken( user );

                AuthResponseDto response = new();

                if (result != null)
                {
                    response.IsSuccess = true;
                    response.Token = result;
                }
                return response;
            }
            catch ( Exception )
            {
                throw;
            }
        }

        public async Task<OperationResult> Register( RegisterUserDto request    )
        {
            try
            {
                var response = new OperationResult();

                var user = mapper.Map<Users>( request );

                var result = await userManager.CreateAsync( user, request.Password );

                if ( !result.Succeeded )
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
}
