namespace ManagementFireEstinguisher.Dto.Prices
{
    public class PrecioBase
    {
        public Guid? IdProductos { get; set; }
        //public int? IdDetalleServ { get; set; } = null;
        public string? Descripcion { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Iva { get; set; }
    }
}
