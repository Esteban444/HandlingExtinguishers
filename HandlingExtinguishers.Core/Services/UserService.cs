using AutoMapper;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguisher.Dto;
using HandlingExtinguisher.Dto.Users;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models.Models;
using HandlingFireExtinguisher.Core.Helpers;
using ManagementFireEstinguisher.Dto.Users;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace HandlingExtinguishers.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Users> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;

        public UserService(UserManager<Users> userManager, IMapper mapper, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        public async Task<AuthResponseDto> Login(LoginRequestDto request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email) ?? throw new Exception("The user does not exist.");

                if (!await _userManager.CheckPasswordAsync(user, request.Password))
                {
                    await _userManager.AccessFailedAsync(user);

                    if (await _userManager.IsLockedOutAsync(user))
                    {

                        return new AuthResponseDto { Errors = new string[] { "The account is blocked." } };
                    }

                    return new AuthResponseDto { Errors = new string[] { "Invalid authentication." } };
                }


                var token = await _jwtHandler.CreateToken(user);

                await _userManager.ResetAccessFailedCountAsync(user);

                return new AuthResponseDto { IsSuccess = true, Token = token };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AuthResponseDto> RefreshToken(string token)
        {
            try
            {
                var validateResult = _jwtHandler.ValidateCurrentToken(token);
                var oldClams = _jwtHandler.ValidatedClaimsCurrentToken(token);
                var handler = new JwtSecurityTokenHandler();
                var expiredToken = handler.ReadToken(token) as JwtSecurityToken;
                var userId = expiredToken?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var user = await _userManager.FindByIdAsync(userId!) ?? throw new HandlingExceptions(HttpStatusCode.BadRequest, new { Mensaje = "The user was not found in the database." });
                var result = await _jwtHandler.CreateToken(user);
                AuthResponseDto response = new();
                if (result != null)
                {
                    response.IsSuccess = true;
                    response.Token = result;
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OperationResult> Register(RegisterUserDto request)
        {
            try
            {
                var response = new OperationResult();

                var user = _mapper.Map<Users>(request);

                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);
                    response.IsSuccess = false;
                    response.Errors = errors;
                    return response;
                }
                response.IsSuccess = true;
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
