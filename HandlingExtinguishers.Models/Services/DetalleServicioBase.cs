namespace ManagementFireEstinguisher.Dto.Services
{
    public class DetalleServicioBase
    {
        public Guid? IdServicios { get; set; }
        public string? Descripcion { get; set; }
        public Guid? IdTipoExtintor { get; set; }
        public Guid? IdPesoExtintor { get; set; }
        public decimal? Valor { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Total { get; set; }
    }
}
