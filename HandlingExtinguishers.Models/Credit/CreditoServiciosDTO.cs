using ManagementFireEstinguisher.Dto.Services;

namespace ManagementFireEstinguisher.Dto.Credit
{
    public class CreditoServiciosDTO : CreditoServicioBase
    {
        public Guid Id { get; set; }
        public ServicioDTO? Servicio { get; set; }
    }
}
