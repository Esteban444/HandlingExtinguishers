using HandlingExtinguishers.Models.Extinguishers;
using ManagementFireEstinguisher.Dto.Products;

namespace HandlingExtinguishers.Models.Products
{
    public class ProductoDTO : ProductoBase
    {
        public int IdProductos { get; set; }
        public WightExtuinguiserDto PesoExtintor { get; set; }
        public TypeExtinguisherRequest TipoExtintor { get; set; }
    }
}
