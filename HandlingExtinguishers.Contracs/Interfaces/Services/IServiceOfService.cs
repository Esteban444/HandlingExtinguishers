using ManagementFireEstinguisher.Dto;
using ManagementFireEstinguisher.Dto.Services;
using ManejoExtintores.Core.Filtros_Busqueda;

namespace HandlingFireExtinguisher.Contracts.Interfaces.Services
{
    public interface IServiceOfService
    {
        Task<IEnumerable<ServicioDTO>> ConsultarServicios(FiltroServicios filtros);
        Task<ServicioDTO> ConsultaServicio(Guid id);
        Task<ServicioBase> CrearServicios(ServicioBase servicio);
        ServicioBase CrearServicioDetalle(ServicioBase servicio);
        Task<ModificarEstado> ActualizarEstado(Guid id, ModificarEstado modificar);
        Task<ServicioBase> ActualizarServicios(Guid id, ServicioBase servicio);
        Task<ServicioDTO> EliminarServicios(Guid id);
    }
}
