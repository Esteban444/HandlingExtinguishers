namespace HandlingExtinguishers.Core.Services;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Clients;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Models;
using Microsoft.EntityFrameworkCore;
#endregion

public class ClientService( IRepositoryClient repository, IMapper mapper ) : IClientService
{
    private readonly IRepositoryClient repository = repository;
    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<ClientRequest>> SearchClients( FilterClient filter )
    {
        var result = await repository.GetAll().ToListAsync();

        if (filter.Name != null)
        {
            result = result.Where(x => x.Name!.ToLower().Contains(filter.Name.ToLower())).ToList();
        }

        if (filter.LastName != null)
        {
            result = result.Where(x => x.LasName!.ToLower().Contains(filter.LastName.ToLower())).ToList();
        }
        var response = mapper.Map<IEnumerable<ClientRequest>>(result);

        return response;
    }

    public async Task<ClientRequest> SearchClientById( Guid clientId )
    {
        var client = await repository.FindBy(client => client.ClientId == clientId).FirstOrDefaultAsync();

        if ( client is null )
        {
            return mapper.Map<ClientRequest>( client );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ClientNotFound );
        }
    }

    public async Task<ClientRequest> CreateClient( ClientRequest request )
    {
        var client = mapper.Map<Client>( request );

        await repository.Add( client );

        var response = mapper.Map<ClientRequest>( client );

        return response;

    }

    public async Task<ClientRequest> UpdateClient( Guid clientId, ClientRequest client )
    {
        var result = await repository.FindBy(c => c.ClientId == clientId).FirstOrDefaultAsync();

        if ( result is not null )
        {
            result.DocumentClient = client.DocumentClient;
            result.Name = client.Name;
            result.LasName = client.LasName;
            result.Description = client.Description;
            result.Address = client.Address;
            result.Phone = client.Phone;
            result.Email = client.Email;
            result.Nit = client.Nit;

            await repository.Update( result );

            var response = mapper.Map<ClientRequest>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ClientNotFound );
        }
    }

    public async Task<ClientRequest> DeleteClient( Guid clientId )
    {
        var result = await repository.FindBy(client => client.ClientId == clientId).FirstOrDefaultAsync();

        if ( result is not null )
        {
            try
            {
                await repository.Delete( result );

                var response = mapper.Map<ClientRequest>( result );

                return response;
            }
            catch ( Exception )
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.RelatedClient );
            }
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ClientNotFound );
        }
    }
}
