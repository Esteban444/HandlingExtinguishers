namespace HandlingExtinguishers.Models.Authentication;

public class AuthenticationResponse : OperationResult
{
    public string? Token { get; set; }

    public string? Expiration { get; set; }
}
