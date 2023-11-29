using HandlingExtinguisher.Dto.Clients;
using ManejoExtintores.Core.Filtros_Busqueda;

namespace HandlingExtinguisher.Contracts.Interfaces.Services
{
    public interface IServicieClient
    {
        Task<IEnumerable<ClientDto>> GetClients(FilterClient filtro);
        Task<ClientDto> GetClient(Guid clientId);
        Task<BaseClient> CreateClient(BaseClient cliente);
        Task<BaseClient> UpdateClient(Guid clientId, BaseClient cliente);
        Task<ClientDto> DeleteClient(Guid clientId);
    }
}
