using ManagementFireEstinguisher.Dto.Inventories;
using ManejoExtintores.Core.Filtros_Busqueda;

namespace HandlingFireExtinguisher.Contracts.Interfaces.Services
{
    public interface IServicioInventario
    {
        Task<IEnumerable<InventarioDTO>> ConsultaInventarios(FiltroInventario filtro);
        Task<InventarioDTO> ConsultaInventarioPorId(Guid id);
        Task<InventarioBase> CrearInventario(InventarioBase inventario);
        Task<InventarioBase> ActualizarInventario(Guid id, InventarioBase inventario);
        Task<InventarioBase> EliminarInventario(Guid id);
    }
}
