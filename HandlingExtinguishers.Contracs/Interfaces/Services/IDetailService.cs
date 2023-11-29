using ManagementFireEstinguisher.Dto.Services;
using ManejoExtintores.Core.Filtros_Busqueda;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IDetailService
    {
        Task<List<DetalleServicioDTO>> ConsultaDetalles(FiltroDetalleServicio filtro);
        public Task<DetalleServicioDTO> ConsultaDetallePorId(Guid id);
        Task<DetalleServicioBase> CrearDetalles(DetalleServicioBase detalle);
        Task<DetalleServicioBase> ActualizarDetalle(Guid id, DetalleServicioBase detalle);
        Task<DetalleServicioDTO> EliminarDetalle(Guid id);
    }
}
