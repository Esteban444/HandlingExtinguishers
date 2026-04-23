namespace HandlingExtinguishers.Models.Authentication;

using System.Security.Claims;

public class TokenClaimsResult: OperationResult
{
    public bool IsValid { get; set; }

    public IEnumerable<Claim>? Claims { get; set; }
}
