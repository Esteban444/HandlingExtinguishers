using System.Security.Claims;

namespace HandlingExtinguishers.Models.Authentication;

public class TokenClaimsResult: OperationResult
{
    public bool IsValid { get; set; }
    public IEnumerable<Claim>? Claims { get; set; }
}
