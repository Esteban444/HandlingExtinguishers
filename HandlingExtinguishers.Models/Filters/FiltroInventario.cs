using System.ComponentModel.DataAnnotations;

namespace ManejoExtintores.Core.Filtros_Busqueda
{
    public class FiltroInventario
    {

        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaVencimiento { get; set; }
    }
}
