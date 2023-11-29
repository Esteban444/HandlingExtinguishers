using ManagementFireEstinguisher.Dto.Products;

namespace ManagementFireEstinguisher.Dto.Prices
{
    public class PrecioDTO : PrecioBase
    {
        public int IdPrecios { get; set; }
        public ProductoDTO Producto { get; set; }
    }
}
