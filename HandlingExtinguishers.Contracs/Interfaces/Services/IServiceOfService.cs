using ManagementFireEstinguisher.Dto;
using ManagementFireEstinguisher.Dto.Services;
using ManejoExtintores.Core.Filtros_Busqueda;

namespace HandlingExtinguishers.Contracts.Interfaces.Services 
{
    public interface IServiceOfService
    {
        Task<IEnumerable<ServicioDTO>> ConsultarServicios(FiltroServicios filtros);
        Task<ServicioDTO> ConsultaServicio(Guid id);
        Task<ServicioBase> CrearServicios(ServicioBase servicio);
        Task<ServicioBase> CrearServicioDetalle(ServicioBase servicio);
        Task<EditStatus> ActualizarEstado(Guid id, EditStatus modificar);
        Task<ServicioBase> ActualizarServicios(Guid id, ServicioBase servicio);
        Task<ServicioDTO> EliminarServicios(Guid id);
    }
}
