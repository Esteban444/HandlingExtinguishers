using HandlingExtinguishers.Models.Extinguishers;
using HandlingExtinguishers.Models.Inventories;
using HandlingExtinguishers.Models.Prices;


namespace HandlingExtinguishers.Models.Services
{
    public class DetalleServicioDTO : DetalleServicioBase
    {
        public int IdDetalleServ { get; set; }

        public WightExtuinguiserDto PesoExtintor { get; set; }
        public ICollection<PrecioDTO> Precios { get; set; }
        public TypeExtinguisherRequest TipoExtintor { get; set; }
        public ICollection<InventarioDTO> Inventarios { get; set; }
    }
}
