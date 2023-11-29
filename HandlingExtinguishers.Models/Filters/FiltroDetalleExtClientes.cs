namespace ManejoExtintores.Core.Filtros_Busqueda
{
    public class FiltroDetalleExtClientes
    {
        public string TipoExtintor { get; set; }
        public DateTime? FechaServicio { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public DateTime? FechaMantenimiento { get; set; }
    }
}
