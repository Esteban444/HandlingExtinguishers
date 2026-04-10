using System.Security.Claims;

namespace HandlingExtinguishers.Models.Authentication
{
    public class TokenValidationDto : OperationResult
    {
        public bool IsValid { get; set; }

        public ClaimsPrincipal? Claims { get; set; }
    }
}
