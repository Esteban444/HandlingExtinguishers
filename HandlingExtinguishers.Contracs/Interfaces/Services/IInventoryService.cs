using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Inventories;
using ManagementFireEstinguisher.Dto.Inventories;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventarioDTO>> ConsultaInventarios(FilterInventory filtro);
        Task<InventarioDTO> ConsultaInventarioPorId(Guid id);
        Task<InventarioBase> CrearInventario(InventarioBase inventario);
        Task<InventarioBase> ActualizarInventario(Guid id, InventarioBase inventario);
        Task<InventarioBase> EliminarInventario(Guid id);
    }
}
