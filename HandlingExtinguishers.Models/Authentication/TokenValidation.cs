namespace HandlingExtinguishers.Models.Authentication;

using System.Security.Claims;

public class TokenValidation : OperationResult
{
    public bool IsValid { get; set; }

    public ClaimsPrincipal? Claims { get; set; }
}
