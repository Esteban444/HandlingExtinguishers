using HandlingExtinguishers.Models.Extinguishers;
using ManagementFireEstinguisher.Dto.Extinguishers;

namespace ManagementFireEstinguisher.Dto.Products
{
    public class ProductoDTO : ProductoBase
    {
        public int IdProductos { get; set; }
        public WightExtuinguiserDto PesoExtintor { get; set; }
        public TipoExtintorDTO TipoExtintor { get; set; }
    }
}
