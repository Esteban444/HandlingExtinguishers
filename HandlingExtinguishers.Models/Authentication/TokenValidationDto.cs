using HandlingExtinguisher.Dto;
using System.Security.Claims;

namespace HandlingExtinguishers.Models.Authentication
{
    public class TokenValidationDto : OperationResult
    {
        public bool IsValid { get; set; }
        public ClaimsPrincipal? Claims { get; set; }
    }

    public class TokenClaimsResult : OperationResult
    {
        public bool IsValid { get; set; }
        public IEnumerable<Claim>? Claims { get; set; }
    }
}
