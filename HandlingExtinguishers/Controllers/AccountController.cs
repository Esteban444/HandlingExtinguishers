namespace HandlingExtinguishers.Controllers;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.CommandServices;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
#endregion

[Route("api/account")]
[ApiController]
[AllowAnonymous]

public class AccountController( IAuthentificationCommandService authentificationService, 
                                IValidator<LoginRequest> validator, 
                                IValidator<RegisterUserRequest> validatorRegister ) : ControllerBase
{
    private readonly IValidator<LoginRequest> validator = validator;
    private readonly IValidator<RegisterUserRequest> validatorRegister = validatorRegister;
    private readonly IAuthentificationCommandService authentificationService = authentificationService;

    [HttpPost("login")]
    public async Task<IActionResult> Login( [FromBody] LoginRequest request )
    {
        var validation = validator.Validate( request );

        if ( !validation.IsValid )
        {
            var errors = validation.Errors.Select( error => error.ErrorMessage );

            return BadRequest( new ErrorResponse { Errors = errors } );
        }

        var result = await authentificationService.Login( request );

        return Ok( result );
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register( [FromBody] RegisterUserRequest request )
    {
        var Validation = validatorRegister.Validate( request );

        if ( !Validation.IsValid )
        {
            var errors = Validation.Errors.Select( error => error.ErrorMessage );

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
