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

public class DetailExtinguisherClientService( IRepositoryDetailExtinguisherClient repositoryDetailExtinguisherClient, 
                                         IMapper mapper ) : IServiceDetailExtinguisherClients
{
    private readonly IRepositoryDetailExtinguisherClient repositoryDetailExtinguisherClient = repositoryDetailExtinguisherClient;
    private readonly IMapper mapper = mapper;

    public async Task<List<DetailExtinguisherClientRequest>> SearchDetailClients( FilterDetailExtClient filter ) 
    {
        var search = await repositoryDetailExtinguisherClient.GetAll().ToListAsync();

        var response = mapper.Map<List<DetailExtinguisherClientRequest>>( search );

        return response;
    }

    public async Task<DetailExtinguisherClientRequest> SearchDetailClientById( Guid idDetail )
    {
        var result = await repositoryDetailExtinguisherClient.FindBy( detail => detail.DetailExtinguisherClientId == idDetail ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            return mapper.Map<Models.Clients.DetailExtinguisherClientRequest>( result );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.DetailExtinguisherClientNotFound );
        }
    }

    public async Task<DetailExtinguisherClientRequest> CreateDetailClient( DetailExtinguisherClientRequest request  )
    {
        var detailExtinguisher = mapper.Map<DetailExtinguisherClient>( request );

        await repositoryDetailExtinguisherClient.Add( detailExtinguisher );

        var result = mapper.Map<DetailExtinguisherClientRequest>( detailExtinguisher );

        return result;
    }

    public async Task<DetailExtinguisherClientRequest> UpdateDetailClient( Guid idDetail, DetailExtinguisherClientRequest request )
    {
        var result = await repositoryDetailExtinguisherClient.FindBy( detail => detail.DetailExtinguisherClientId == idDetail ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            result.ClientId = request.IdClients;
            result.TypeExtinguisher = request.TypeExtinguisher ?? result.TypeExtinguisher;
            result.WeightExtinguisher = request.TypeExtinguisher ?? result.TypeExtinguisher;
            result.Quantity = request.Quantity ?? result.Quantity;
            result.MaintenanceDate = request.MaintenanceDate ?? result.MaintenanceDate;
            result.ExpirationDate = request.ExpirationDate ?? result.ExpirationDate;

            await repositoryDetailExtinguisherClient.Update( result );

            var response = mapper.Map<DetailExtinguisherClientRequest>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.DetailExtinguisherClientNotFound );
        }
    }

    public async Task<DetailExtinguisherClientRequest> DeleteDetailClient( Guid idDetail )
    {
        var result = await repositoryDetailExtinguisherClient.FindBy( detail => detail.DetailExtinguisherClientId == idDetail ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            try
            {
                await repositoryDetailExtinguisherClient.Delete( result );

                var response = mapper.Map<DetailExtinguisherClientRequest>( result );

                return response;
            }
            catch ( Exception )
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.RelatedDetailExtinguisherClient );
            }
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.DetailExtinguisherClientNotFound );
        }

    }
}
