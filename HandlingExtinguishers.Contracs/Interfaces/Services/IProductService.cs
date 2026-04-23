using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Products;
using ManagementFireEstinguisher.Dto.Products;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductoDTO>> ConsultaProductos(FiltroProductos filtros);
        Task<ProductoDTO> ConsultaPorId(Guid id);
        Task<ProductoBase> CrearProducto(ProductoBase producto);
        Task<ProductoBase> ActualizarProducto(Guid id, ProductoBase producto);
        Task<ProductoBase> EliminarProducto(Guid id);
    }
}
