namespace HandlingExtinguishers.Models.Authentication;

public class RegisterUserRequest
{
    public required string FullName { get; set; }

    public required string UserName { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }
}
