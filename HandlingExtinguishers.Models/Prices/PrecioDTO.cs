using HandlingExtinguishers.Models.Products;

namespace HandlingExtinguishers.Models.Prices
{
    public class PrecioDTO : PrecioBase
    {
        public int IdPrecios { get; set; }
        public ProductoDTO Producto { get; set; }
    }
}
