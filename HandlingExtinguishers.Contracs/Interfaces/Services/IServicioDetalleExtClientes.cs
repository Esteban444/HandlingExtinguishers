using HandlingExtinguisher.Dto.Clients;
using ManejoExtintores.Core.Filtros_Busqueda;

namespace HandlingExtinguisher.Contracts.Interfaces.Services
{
    public interface IServicioDetalleExtClientes
    {
        Task<List<DetailExtinguisherClientDto>> ConsultaDetalleClientes(FiltroDetalleExtClientes filtro);
        Task<DetailExtinguisherClientDto> ConsultaDetalleExtClientePorId(Guid id);
        Task<BaseDetailExtinguisherClient> CrearDetalleExtCliente(BaseDetailExtinguisherClient detalleExtCliente);
        Task<BaseDetailExtinguisherClient> ActualizarDetalleExtCliente(Guid id, BaseDetailExtinguisherClient detalleExtCliente);
        Task<DetailExtinguisherClientDto> EliminarDetalleExtCliente(Guid id);
    }
}
