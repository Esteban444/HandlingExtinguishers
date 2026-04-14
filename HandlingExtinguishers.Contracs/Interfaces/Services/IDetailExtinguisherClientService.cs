namespace HandlingExtinguishers.Contracts.Interfaces.Services;

#region Usings
using HandlingExtinguisher.Dto.Clients;
using ManejoExtintores.Core.Filtros_Busqueda;
#endregion

public interface IServiceDetailExtinguisherClients 
{
    Task<List<DetailExtinguisherClientDto>> SearchDetailClients( FiltroDetalleExtClientes filter );
    Task<DetailExtinguisherClientDto> SearchDetailClientById( Guid idDetail );
    Task<BaseDetailExtinguisherClient> CreateDetailClient( BaseDetailExtinguisherClient detailExtinguisherClient );
    Task<BaseDetailExtinguisherClient> UpdateDetailClient( Guid idDetail, BaseDetailExtinguisherClient detailExtinguisherClient );
    Task<DetailExtinguisherClientDto> DeleteDetailClient( Guid idDetail );
}
