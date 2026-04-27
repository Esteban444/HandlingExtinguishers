namespace HandlingExtinguishers.Contracts.Interfaces;

#region Usings
using HandlingExtinguishers.Models.Clients;
using HandlingExtinguishers.Models.Filters;
#endregion

public interface IServiceDetailExtinguisherClients 
{
    Task<List<DetailExtinguisherClientResponse>> SearchDetailClients( FilterDetailExtClient filter );

    Task<DetailExtinguisherClientResponse> SearchDetailClientById( Guid detailId );

    Task<DetailExtinguisherClientResponse> CreateDetailClient( DetailExtinguisherClientRequest request );

    Task<DetailExtinguisherClientResponse> UpdateDetailClient( Guid detailId, DetailExtinguisherClientRequest request );

    Task<DetailExtinguisherClientResponse> DeleteDetailClient( Guid detailId );
}
