using ManagementFireEstinguisher.Dto.Credit;
using ManejoExtintores.Core.Filtros_Busqueda;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServicieCredit
    {
        Task<List<CreditoServiciosDTO>> ConsultaCreditos(FiltroCreditos filtros);
        Task<CreditoServiciosDTO> ConsultaCreditoPorId(Guid id);
        Task<CreditoServicioBase> CrearCredito(CreditoServicioBase credito);
        Task<CreditoServicioBase> ActualizarCredito(Guid id, CreditoServicioBase credito);
        Task<CreditoServiciosDTO> EliminarCredito(Guid id);
    }
}
