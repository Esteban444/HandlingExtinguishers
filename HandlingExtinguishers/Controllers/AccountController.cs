using FluentValidation;
using HandlingExtinguisher.Dto.Users;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HandlingExtinguishers.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]

    public class AccountController( IAuthentificationService userService, IValidator<LoginRequestDto> validatoraut ) : ControllerBase
    {
        private readonly IValidator<LoginRequestDto> validatorAuten = validatoraut;
        private readonly IAuthentificationService userService = userService;

        [HttpPost("login")]
        public async Task<IActionResult> Loguin( [FromBody] LoginRequestDto request )
        {
            var result = await userService.Login( request );

            return Ok( result );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register( [FromBody] RegisterUserDto request )
        {
            var result = await userService.Register( request );

            return Ok( result );
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken( [FromHeader] string authorization )
        {
            if (AuthenticationHeaderValue.TryParse( authorization, out var headerValue ) )
            {
                var token = headerValue.Parameter;

                var result = await userService.RefreshToken(token!);

                return Ok( result );
            }

            return BadRequest();
        }

    }
}
