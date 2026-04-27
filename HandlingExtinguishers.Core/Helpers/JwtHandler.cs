using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Authentication;
using HandlingExtinguishers.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HandlingExtinguishers.Core.Helpers
{
    public class JwtHandler
    {
        private readonly IConfiguration configuration;
        private readonly IConfigurationSection jwtConfiguration;
        private readonly UserManager<Users> userManager;

        public JwtHandler( IConfiguration configuration, UserManager<Users> userManager )
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.jwtConfiguration = this.configuration.GetSection( CommonConstants.SettingsJWTConfiguracion );
        }

        private SigningCredentials GetSignatureCredentials()
        {
            var key = Encoding.UTF8.GetBytes( jwtConfiguration.GetSection( CommonConstants.JwtSecurityKeyName ).Value! );
            var secret = new SymmetricSecurityKey( key );

            return new SigningCredentials( secret, SecurityAlgorithms.HmacSha256 );
        }

        private async Task<List<Claim>> GetClaims(Users user)
        {
            var claims = new List<Claim>
            {
                new( ClaimTypes.NameIdentifier, user.Id! ),
                new( ClaimTypes.Email, user.Email! ),            
                new( ClaimTypes.Name, user.UserName! ),          
                new( JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString() ),                
                new( JwtRegisteredClaimNames.Iat,DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64 ),
            };

            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GetTokenOptions( SigningCredentials signingCredentials, List<Claim> claims )
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: jwtConfiguration.GetSection( CommonConstants.JwtValidIssuerKeyName).Value,
                audience: jwtConfiguration.GetSection( CommonConstants.JwtValidAudienceKeyName).Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes( Convert.ToDouble( jwtConfiguration.GetSection( CommonConstants.ExpiryInMinutes ).Value ) ),
                signingCredentials: signingCredentials );

            return tokenOptions;
        }

        public async Task<AuthenticationResponse> CreateToken( Users user )
        {
            var signingCredential = GetSignatureCredentials();
            var claims = await GetClaims( user );
            var optionsToken = GetTokenOptions( signingCredential, claims );
            var token = new JwtSecurityTokenHandler().WriteToken( optionsToken );

            var response = new AuthenticationResponse
            {
                Token = token,
                Expiration = optionsToken.ValidTo.ToString( CommonConstants.DateTimeFormat )
            };

            return response;
        }

        public TokenValidation ValidateCurrentToken( string token )
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var mySecurityKey = new SymmetricSecurityKey( Encoding.ASCII.GetBytes( jwtConfiguration.GetSection( CommonConstants.JwtSecurityKeyName ).Value! ) );
                TokenValidationParameters validationParameters = new()
                {
                    ValidIssuer = jwtConfiguration.GetSection( CommonConstants.JwtValidIssuerKeyName ).Value,
                    ValidAudiences = [jwtConfiguration.GetSection( CommonConstants.JwtValidAudienceKeyName ).Value],
                    IssuerSigningKeys = [mySecurityKey]
                };

                var claims = tokenHandler.ValidateToken( token, validationParameters, out SecurityToken validatedToken );

                return new TokenValidation
                {
                    IsSuccess = true,
                    Claims = claims
                };
            }
            catch ( Exception )
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.InvalidToken );
            }
        }

        public TokenClaimsResult ValidatedClaimsCurrentToken( string token )
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var claims = tokenHandler.ReadJwtToken( token );

                return new TokenClaimsResult
                {
                    IsSuccess = true,
                    Claims = claims.Claims
                };
            }
            catch ( Exception )
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.InvalidToken );
            }
        }
    }
}
