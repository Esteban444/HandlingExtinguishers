using HandlingExtinguishers.Models.Extinguishers;
using HandlingExtinguishers.Models.Products;
using ManagementFireEstinguisher.Dto.Inventories;

namespace HandlingExtinguishers.Models.Inventories
{
    public class InventarioDTO : InventarioBase
    {
        public int IdInventario { get; set; }

        public ProductoDTO Producto { get; set; }

        public WightExtuinguiserDto PesoExtintor { get; set; }

        public TypeExtinguisherRequest TipoExtintor { get; set; }
    }
}
