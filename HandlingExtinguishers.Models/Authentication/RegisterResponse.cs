namespace HandlingExtinguishers.Models.Authentication;

public class RegisterResponse 
{
    public bool IsSuccess { get; set; }

    public IEnumerable<string>? Errors { get; set; }
}
