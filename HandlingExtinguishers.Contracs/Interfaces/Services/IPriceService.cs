namespace HandlingExtinguishers.Contracts.Interfaces.Services;

using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Prices;

public interface IPriceService 
{
    Task<IEnumerable<PrecioDTO>> ConsultaPrecios( FilterPrices filtro);
    Task<PrecioDTO> ConsultaPor(Guid id);
    Task<PrecioBase> CrearPrecio(PrecioBase precio);
    Task<PrecioBase> ActualizarPrecio(Guid id, PrecioBase precio);
    Task<PrecioDTO> EliminarPrecio(Guid id);
}
