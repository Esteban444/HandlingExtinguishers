

using System.ComponentModel.DataAnnotations;

namespace ManagementFireEstinguisher.Dto.Users
{
    public class OlvidoContraseñaDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ClientURI { get; set; }
    }
}
