using HandlingExtinguishers.Models.Extinguishers;
using ManagementFireEstinguisher.Dto.Extinguishers;
using ManagementFireEstinguisher.Dto.Products;

namespace ManagementFireEstinguisher.Dto.Inventories
{
    public class InventarioDTO : InventarioBase
    {
        public int IdInventario { get; set; }
        public ProductoDTO Producto { get; set; }
        public WightExtuinguiserDto PesoExtintor { get; set; }
        public TipoExtintorDTO TipoExtintor { get; set; }
    }
}
