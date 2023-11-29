using AutoMapper;
using HamdlingExtinguisher.Dto.Users;
using HandlingExtinguisher.Dto.Users;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Dto.Models;
using HandlingFireExtinguisher.Core.Helpers;
using ManagementFireEstinguisher.Dto.Users;
using Microsoft.AspNetCore.Identity;

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

                        return new AuthResponseDto { MensajeError = "The account is blocked." };
                    }

                    return new AuthResponseDto { MensajeError = "Invalid authentication." };
                }


                var token = await _jwtHandler.CreateToken(user);

                await _userManager.ResetAccessFailedCountAsync(user);

                return new AuthResponseDto { AuthExitosa = true, Token = token };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<AuthResponseDto> RefreshToken(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterResponseDto> Register(RegisterUserDto request)
        {
            try
            {
                var response = new RegisterResponseDto();

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
