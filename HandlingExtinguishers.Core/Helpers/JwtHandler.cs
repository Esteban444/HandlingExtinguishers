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
            var key = Encoding.UTF8.GetBytes( jwtConfiguration.GetSection( "securityKey" ).Value! );
            var secret = new SymmetricSecurityKey( key );

            return new SigningCredentials( secret, SecurityAlgorithms.HmacSha256 );
        }

        private async Task<List<Claim>> GetClaims( Users user )
        {
            var claims = new List<Claim>
            {
                new( ClaimTypes.NameIdentifier, user.Id! )
            };

            var roles = await userManager.GetRolesAsync( user );
            foreach ( var role in roles )
            {
                claims.Add( new Claim(ClaimTypes.Role, role ) );
            }

            return claims;
        }

        private JwtSecurityToken GetTokenOptions( SigningCredentials signingCredentials, List<Claim> claims )
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: jwtConfiguration.GetSection( "validIssuer" ).Value,
                audience: jwtConfiguration.GetSection( "validAudience" ).Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes( Convert.ToDouble( jwtConfiguration.GetSection( "expiryInMinutes" ).Value ) ),
                signingCredentials: signingCredentials );

            return tokenOptions;
        }

        public async Task<string> CreateToken( Users user )
        {
            var firmacredenciales = GetSignatureCredentials();
            var claims = await GetClaims( user );
            var opcionestoken = GetTokenOptions( firmacredenciales, claims );
            var token = new JwtSecurityTokenHandler().WriteToken( opcionestoken );

            return token;
        }

        public TokenValidationDto ValidateCurrentToken( string token )
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var mySecurityKey = new SymmetricSecurityKey( Encoding.ASCII.GetBytes( jwtConfiguration.GetSection( "securityKey" ).Value! ) );
                TokenValidationParameters validationParameters = new()
                {
                    ValidIssuer = jwtConfiguration.GetSection("validIssuer").Value,
                    ValidAudiences = [jwtConfiguration.GetSection("validAudience").Value],
                    IssuerSigningKeys = [mySecurityKey]
                };

                var claimsPrincipal = tokenHandler.ValidateToken( token, validationParameters, out SecurityToken validatedToken );

                return new TokenValidationDto
                {
                    IsSuccess = true,
                    Claims = claimsPrincipal
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
                var claimsPrincipal = tokenHandler.ReadJwtToken( token );

                return new TokenClaimsResult
                {
                    IsSuccess = true,
                    Claims = claimsPrincipal.Claims
                };
            }
            catch (Exception)
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.InvalidToken );
            }
        }
    }
}
