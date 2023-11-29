using System.ComponentModel.DataAnnotations;

namespace ManagementFireEstinguisher.Dto.Services
{
    public class ServicioBase
    {
        public Guid? IdClientes { get; set; }
        public Guid? IdEmpleados { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaServicio { get; set; }
        public decimal? Valor { get; set; }
        public string? Estado { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaVencimiento { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaMantenimiento { get; set; }
        public decimal? Abono { get; set; }

        public List<DetalleServicioBase> DetalleServicios { get; set; }
    }
}
