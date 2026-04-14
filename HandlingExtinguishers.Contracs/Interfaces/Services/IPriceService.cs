using ManagementFireEstinguisher.Dto.Prices;
using ManejoExtintores.Core.Filtros_Busqueda;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IPriceService 
    {
        Task<IEnumerable<PrecioDTO>> ConsultaPrecios(FiltroPrecios filtro);
        Task<PrecioDTO> ConsultaPor(Guid id);
        Task<PrecioBase> CrearPrecio(PrecioBase precio);
        Task<PrecioBase> ActualizarPrecio(Guid id, PrecioBase precio);
        Task<PrecioDTO> EliminarPrecio(Guid id);
    }
}
