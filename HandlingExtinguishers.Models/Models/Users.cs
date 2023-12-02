using Microsoft.AspNetCore.Identity;

namespace HandlingExtinguishers.Models.Models
{
    public class Users : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
