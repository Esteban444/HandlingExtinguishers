using System.ComponentModel.DataAnnotations;


namespace ManagementFireEstinguisher.Dto.Users
{
    public class RestablecerContraseñaDTO
    {
        [Required(ErrorMessage = "El Campo contraseña no puede ir vacío. ")]
        public string Contrasena { get; set; }

        [Compare("Contrasena", ErrorMessage = "Las contraseñas no coinsiden.")]
        public string ConfirmarContrasena { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
