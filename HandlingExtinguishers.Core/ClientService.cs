namespace HandlingExtinguishers.Core;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Clients;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Models;
using Microsoft.EntityFrameworkCore;
#endregion

public class ClientService( IClientRepository repository, IMapper mapper ) : IClientService
{
    private readonly IClientRepository repository = repository;
    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<ClientResponse>> SearchClients( FilterClient filter )
    {
        var result = await repository.GetAll().ToListAsync();

        if (filter.Name != null)
        {
            result = result.Where(x => x.Name!.ToLower().Contains(filter.Name.ToLower())).ToList();
        }

        if (filter.LastName != null)
        {
            result = result.Where(x => x.LastName!.ToLower().Contains(filter.LastName.ToLower())).ToList();
        }
        var response = mapper.Map<IEnumerable<ClientResponse>>(result);

        return response;
    }

    public async Task<ClientResponse> SearchClientById( Guid clientId )
    {
        var client = await repository.FindBy(client => client.ClientId == clientId).FirstOrDefaultAsync();

        if ( client is not null )
        {
            return mapper.Map<ClientResponse>( client );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ClientNotFound );
        }
    }

    public async Task<ClientResponse> CreateClient( ClientRequest request )
    {
        var client = mapper.Map<Client>( request );

        await repository.Add( client );

        var response = mapper.Map<ClientResponse>( client );

        return response;

    }

    public async Task<ClientResponse> UpdateClient( Guid clientId, ClientRequest client )
    {
        var result = await repository.FindBy(c => c.ClientId == clientId).FirstOrDefaultAsync();

        if ( result is not null )
        {
            result.DocumentNumber = client.DocumentNumber;
            result.Name = client.Name;
            result.LastName = client.LastName;
            result.Description = client.Description;
            result.Address = client.Address;
            result.Phone = client.Phone;
            result.Email = client.Email;
            result.Nit = client.Nit;

            await repository.Update( result );

            var response = mapper.Map<ClientResponse>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ClientNotFound );
        }
    }

    public async Task<ClientResponse> DeleteClient( Guid clientId )
    {
        var result = await repository.FindBy(client => client.ClientId == clientId).FirstOrDefaultAsync();

        if ( result is not null )
        {
            try
            {
                await repository.Delete( result );

                var response = mapper.Map<ClientResponse>( result );

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
