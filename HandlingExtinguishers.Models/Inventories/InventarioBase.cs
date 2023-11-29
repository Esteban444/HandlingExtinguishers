using System.ComponentModel.DataAnnotations;

namespace ManagementFireEstinguisher.Dto.Inventories
{
    public class InventarioBase
    {
        public Guid? IdProductos { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public Guid? IdTipoExtintor { get; set; }
        public Guid? IdPesoExtintor { get; set; }
        public int? Cantidad { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaVencimiento { get; set; }
        //public int? DetalleServId { get; set; }
    }
}
