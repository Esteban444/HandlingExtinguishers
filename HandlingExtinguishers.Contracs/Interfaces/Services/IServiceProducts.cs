using ManagementFireEstinguisher.Dto.Products;
using ManejoExtintores.Core.Filtros_Busqueda;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServiceProducts
    {
        Task<IEnumerable<ProductoDTO>> ConsultaProductos(FiltroProductos filtros);
        Task<ProductoDTO> ConsultaPorId(Guid id);
        Task<ProductoBase> CrearProducto(ProductoBase producto);
        Task<ProductoBase> ActualizarProducto(Guid id, ProductoBase producto);
        Task<ProductoBase> EliminarProducto(Guid id);
    }
}
