namespace HandlingExtinguishers.Contracts.Interfaces.Services;

using HandlingExtinguishers.Models.Clients;
using HandlingExtinguishers.Models.Filters;

public interface IClientService
{
    Task<IEnumerable<ClientRequest>> SearchClients( FilterClient filtro );
    Task<ClientRequest> SearchClientById( Guid clientId );
    Task<ClientRequest> CreateClient( ClientRequest cliente );
    Task<ClientRequest> UpdateClient( Guid clientId, ClientRequest cliente );
    Task<ClientRequest> DeleteClient( Guid clientId );
}
