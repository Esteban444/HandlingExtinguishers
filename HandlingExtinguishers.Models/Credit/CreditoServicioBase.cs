using System.ComponentModel.DataAnnotations;

namespace ManagementFireEstinguisher.Dto.Credit
{
    public class CreditoServicioBase
    {
        public Guid? IdServicio { get; set; }
        public decimal? Abono { get; set; }
        public decimal? Deuda { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }
    }
}
