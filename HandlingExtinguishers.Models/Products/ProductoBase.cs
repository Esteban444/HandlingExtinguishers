namespace ManagementFireEstinguisher.Dto.Products
{
    public class ProductoBase
    {
        public Guid? IdTipoExtintor { get; set; } = null;
        public Guid? IdPesoExtintor { get; set; } = null;
        public string? TipoProducto { get; set; }
    }
}
