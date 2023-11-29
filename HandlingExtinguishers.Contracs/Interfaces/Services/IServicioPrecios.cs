using ManagementFireEstinguisher.Dto.Prices;
using ManejoExtintores.Core.Filtros_Busqueda;

namespace HandlingFireExtinguisher.Contracts.Interfaces.Services
{
    public interface IServicioPrecios
    {
        Task<IEnumerable<PrecioDTO>> ConsultaPrecios(FiltroPrecios filtro);
        Task<PrecioDTO> ConsultaPor(Guid id);
        Task<PrecioBase> CrearPrecio(PrecioBase precio);
        Task<PrecioBase> ActualizarPrecio(Guid id, PrecioBase precio);
        Task<PrecioDTO> EliminarPrecio(Guid id);
    }
}
