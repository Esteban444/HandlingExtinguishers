namespace HandlingExtinguisher.Dto.Users
{
    public class AuthResponseDto
    {
        public bool AuthExitosa { get; set; }
        public string? MensajeError { get; set; }
        public string? Token { get; set; }
        public bool Verificacion { get; set; }
        public string? Provider { get; set; }
    }
}
