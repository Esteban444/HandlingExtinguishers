using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Authentication;
using ManagementFireEstinguisher.Dto.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HandlingExtinguishers.Controllers
{
    [Route("api/account")]
    [ApiController]
    [AllowAnonymous]

    public class AccountController( IAuthentificationService authentificationService, 
                                    IValidator<LoginRequest> validator, 
                                    IValidator<RegisterUserDto> validatorRegister ) : ControllerBase
    {
        private readonly IValidator<LoginRequest> validator = validator;
        private readonly IValidator<RegisterUserDto> validatorRegister = validatorRegister;
        private readonly IAuthentificationService authentificationService = authentificationService;

        [HttpPost("login")]
        public async Task<IActionResult> Loguin( [FromBody] LoginRequest request )
        {
            var Validacion = validator.Validate( request );

            if ( !Validacion.IsValid )
            {
                var errors = Validacion.Errors.Select( error => error.ErrorMessage );

                return BadRequest( new ErrorResponse { Errors = errors } );
            }

            var result = await authentificationService.Login( request );

            return Ok( result );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register( [FromBody] RegisterUserDto request )
        {
            var Validacion = validatorRegister.Validate( request );

            if ( !Validacion.IsValid )
            {
                var errors = Validacion.Errors.Select( error => error.ErrorMessage );

                return BadRequest( new ErrorResponse { Errors = errors } );
            }

            var result = await authentificationService.Register( request );

            return Ok( result );
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken( [FromHeader] string authorization )
        {
            if ( string.IsNullOrEmpty( authorization ) )
                return BadRequest( new ErrorResponse { Errors = [ValidatorMessageCommonConstants.TokenRequired] } );

            if ( !AuthenticationHeaderValue.TryParse( authorization, out var headerValue ) )
                return BadRequest( new ErrorResponse { Errors = [ValidatorMessageCommonConstants.InvalidAuthorizationFormat] } );

            var token = headerValue.Parameter;

            if ( string.IsNullOrWhiteSpace( token ) )
                return BadRequest( new ErrorResponse { Errors = [ValidatorMessageCommonConstants.TokenCannotBeEmpty] } );

            var result = await authentificationService.RefreshToken( token );

            return Ok( result );
        }

    }
}
