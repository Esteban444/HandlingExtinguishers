namespace HandlingExtinguishers.Contracts.Interfaces.Services;

#region Usings
using HandlingExtinguishers.Models.Clients;
using HandlingExtinguishers.Models.Filters;
#endregion

public interface IServiceDetailExtinguisherClients 
{
    Task<List<DetailExtinguisherClientRequest>> SearchDetailClients( FilterDetailExtClient filter );
    Task<DetailExtinguisherClientRequest> SearchDetailClientById( Guid idDetail );
    Task<DetailExtinguisherClientRequest> CreateDetailClient( DetailExtinguisherClientRequest detailExtinguisherClient );
    Task<DetailExtinguisherClientRequest> UpdateDetailClient( Guid idDetail, DetailExtinguisherClientRequest detailExtinguisherClient );
    Task<DetailExtinguisherClientRequest> DeleteDetailClient( Guid idDetail );
}
