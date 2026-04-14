namespace HandlingExtinguishers.Core.Services;

#region Usings
using AutoMapper;
using HandlingExtinguisher.Dto.Clients;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Models;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.EntityFrameworkCore;
#endregion

public class ServicioDetalleExtClientes( IRepositoryDetailExtinguisherClient repositoryDetailExtinguisherClient, 
                                         IMapper mapper ) : IServiceDetailExtinguisherClients
{
    private readonly IRepositoryDetailExtinguisherClient repositoryDetailExtinguisherClient = repositoryDetailExtinguisherClient;
    private readonly IMapper mapper = mapper;

    public async Task<List<DetailExtinguisherClientDto>> SearchDetailClients( FiltroDetalleExtClientes filter ) 
    {
        var search = await repositoryDetailExtinguisherClient.GetAll().ToListAsync();

        var response = mapper.Map<List<DetailExtinguisherClientDto>>( search );

        return response;
    }

    public async Task<DetailExtinguisherClientDto> SearchDetailClientById( Guid idDetail )
    {
        var result = await repositoryDetailExtinguisherClient.FindBy( detail => detail.Id == idDetail ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            return mapper.Map<DetailExtinguisherClientDto>( result );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.DetailExtinguisherClientNotFound );
        }
    }

    public async Task<BaseDetailExtinguisherClient> CreateDetailClient( BaseDetailExtinguisherClient request  )
    {
        var detailExtinguisher = mapper.Map<DetailExtinguisherClient>( request );

        await repositoryDetailExtinguisherClient.Add( detailExtinguisher );

        var result = mapper.Map<BaseDetailExtinguisherClient>( detailExtinguisher );

        return result;
    }

    public async Task<BaseDetailExtinguisherClient> UpdateDetailClient( Guid idDetail, BaseDetailExtinguisherClient request )
    {
        var result = await repositoryDetailExtinguisherClient.FindBy( detail => detail.Id == idDetail ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            result.IdClients = request.IdClients;
            result.TypeExtinguisher = request.TypeExtinguisher ?? result.TypeExtinguisher;
            result.WeightExtinguisher = request.TypeExtinguisher ?? result.TypeExtinguisher;
            result.Quantity = request.Quantity ?? result.Quantity;
            result.MaintenanceDate = request.MaintenanceDate ?? result.MaintenanceDate;
            result.ExpirationDate = request.ExpirationDate ?? result.ExpirationDate;

            await repositoryDetailExtinguisherClient.Update( result );

            var response = mapper.Map<BaseDetailExtinguisherClient>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.DetailExtinguisherClientNotFound );
        }
    }

    public async Task<DetailExtinguisherClientDto> DeleteDetailClient( Guid idDetail )
    {
        var result = await repositoryDetailExtinguisherClient.FindBy( detail => detail.Id == idDetail ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            try
            {
                await repositoryDetailExtinguisherClient.Delete( result );

                var response = mapper.Map<DetailExtinguisherClientDto>( result );

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
