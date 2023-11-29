using FluentValidation;
using HandlingExtinguisher.Dto.Users;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HandlingFireExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]

    public class AccountController : ControllerBase
    {
        private readonly IValidator<LoginRequestDto> _validatorAuten;
        private readonly IValidator<VerificacionDosPasosDTO> _validatorVerif;
        private readonly IUserService _userService;

        public AccountController(IUserService userService, IValidator<LoginRequestDto> validatoraut,
            IValidator<VerificacionDosPasosDTO> validatorVerif)
        {
            this._userService = userService;
            _validatorAuten = validatoraut;
            _validatorVerif = validatorVerif;
        }

        [HttpPost("login")]
        public async Task<IActionResult> InicioSeccion([FromBody] LoginRequestDto request)
        {
            var result = await _userService.Login(request);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] RegisterUserDto request)
        {
            var result = await _userService.Register(request);
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromHeader] string authorization)
        {
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                var token = headerValue.Parameter;
                var result = await _userService.RefreshToken(token!);
                return Ok(result);
            }
            return BadRequest();
        }

        /*[HttpPost("VerificacionEnDosPasos")]
		public async Task<IActionResult> VerificacionDosPasos([FromBody] VerificacionDosPasosDTO verificacionDosPasosDTO)
		{
			var Validacion = _validatorVerif.Validate(verificacionDosPasosDTO);
			if (!Validacion.IsValid)
			{
				var errors = Validacion.Errors.Select(e => e.ErrorMessage);

				return BadRequest(new RespuestaVerifDosPasos { Errors = errors });
			}

			var usuario = await _userManager.FindByEmailAsync(verificacionDosPasosDTO.Email);
			if (usuario == null)
				return BadRequest("El usurio invalido");

			var Verificacion = await _userManager.VerifyTwoFactorTokenAsync(usuario, verificacionDosPasosDTO.Provider, verificacionDosPasosDTO.Token);
			if (!Verificacion)
				return BadRequest("verificacion token invalido");

			var token = await _jwtHandler.GenerarToken(usuario);
			return Ok(new AuthRespuestaDTO { AuthExitosa = true, Token = token });
		}
		 
		[HttpPost("OlvidoContraseña")]
		public async Task<IActionResult> OlvidoContraceña([FromBody] OlvidoContraseñaDTO olvidoContraseña)
		{
			if (!ModelState.IsValid) 
				return BadRequest();

			var usuario = await _userManager.FindByEmailAsync(olvidoContraseña.Email);
			if (usuario == null)
				return BadRequest("Usuario Invalido.");

			var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
			var param = new Dictionary<string, string>
			{
				{"token", token },
				{"email", olvidoContraseña.Email }
			};

			var callback = QueryHelpers.AddQueryString(olvidoContraseña.ClientURI, param);

			//var message = new Message(new string[] { "codemazetest@gmail.com" }, "Reset password token", callback, null);
			//await _emailSender.SendEmailAsync(message);

			return Ok();
		}

		[HttpPost("RestablecerContraseña")]
		public async Task<IActionResult> ResetPassword([FromBody] RestablecerContraseñaDTO restablecerContraseña)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var usuario = await _userManager.FindByEmailAsync(restablecerContraseña.Email);
			if (usuario == null) 
				return BadRequest("Usuario invalido.");

			var resetPassResult = await _userManager.ResetPasswordAsync(usuario, restablecerContraseña.Token, restablecerContraseña.Contrasena);
			if (!resetPassResult.Succeeded)
			{
				var errors = resetPassResult.Errors.Select(e => e.Description);

				return BadRequest(new { Errors = errors });
			}

			await _userManager.SetLockoutEndDateAsync(usuario, new DateTime(2000, 1, 1));

			return Ok();
		}

		[HttpGet("EmailConfirmacion")]
		public async Task<IActionResult> EmailConfirmation([FromQuery] string email, [FromQuery] string token)
		{
			var usuario = await _userManager.FindByEmailAsync(email);
			if (usuario == null)
				return BadRequest("Email de usuario invalido");

			var confirmResult = await _userManager.ConfirmEmailAsync(usuario, token);
			if (!confirmResult.Succeeded)
				return BadRequest("Solicitud de confirmación por correo electrónico no válida.");

			return Ok();
		}*/

    }
}
