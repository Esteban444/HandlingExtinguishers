using ManagementFireEstinguisher.Dto.Extinguishers;
using ManagementFireEstinguisher.Dto.Inventories;
using ManagementFireEstinguisher.Dto.Prices;

namespace ManagementFireEstinguisher.Dto.Services
{
    public class DetalleServicioDTO : DetalleServicioBase
    {
        public int IdDetalleServ { get; set; }

        public PesoExtintorDTO PesoExtintor { get; set; }
        public ICollection<PrecioDTO> Precios { get; set; }
        public TipoExtintorDTO TipoExtintor { get; set; }
        public ICollection<InventarioDTO> Inventarios { get; set; }
    }
}
