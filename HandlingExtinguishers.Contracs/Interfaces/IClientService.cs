namespace HandlingExtinguishers.Contracts.Interfaces;

using HandlingExtinguishers.Models.Clients;
using HandlingExtinguishers.Models.Filters;

public interface IClientService
{
    Task<IEnumerable<ClientResponse>> SearchClients( FilterClient filtro );

    Task<ClientResponse> SearchClientById( Guid clientId );

    Task<ClientResponse> CreateClient( ClientRequest cliente );

    Task<ClientResponse> UpdateClient( Guid clientId, ClientRequest cliente );

    Task<ClientResponse> DeleteClient( Guid clientId );
}
