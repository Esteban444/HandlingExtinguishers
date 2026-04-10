using HandlingExtinguishers.Models;

namespace HandlingExtinguisher.Dto.Users
{
    public class AuthResponseDto : OperationResult
    {
        public string? Token { get; set; }
        public string? Expiration { get; set; }
    }
}
