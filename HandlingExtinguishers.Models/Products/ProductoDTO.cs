using ManagementFireEstinguisher.Dto.Extinguishers;

namespace ManagementFireEstinguisher.Dto.Products
{
    public class ProductoDTO : ProductoBase
    {
        public int IdProductos { get; set; }
        public PesoExtintorDTO PesoExtintor { get; set; }
        public TipoExtintorDTO TipoExtintor { get; set; }
    }
}
