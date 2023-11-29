using Microsoft.AspNetCore.Identity;

namespace HandlingExtinguishers.Dto.Models
{
    public class Users : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
