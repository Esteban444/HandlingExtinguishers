namespace HandlingExtinguishers.Core.Services;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Services;
using Microsoft.EntityFrameworkCore;
#endregion

public class ServiceOfService(IServiceRepository repository, IMapper mapper) : IServiceOfService
{
    private readonly IServiceRepository repository = repository;

    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<ServiceRequest>> SearchServices( FilterService filtros )
    {
        var result = await repository.GetAll().ToListAsync();

        var response = mapper.Map<IEnumerable<ServiceRequest>>( result );

        return response; 
    }

    public async Task<ServiceRequest> SearchServiceById( Guid idService )
    {
        var result = await repository.FindBy( service => service.ServiceId == idService ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            return mapper.Map<ServiceRequest>( result );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ServiceNotFound );
        }
    }

    public async Task<ServiceRequest> CreateServiceDetail( ServiceRequest request )
    {
        // await _repositorio.Add(serviciob);
        var response = mapper.Map<ServiceRequest>( request );

        return response;
    }

    public async Task<ServiceRequest> CreateService( ServiceRequest request )
    {
        var result = mapper.Map<Models.Models.Service>( request );

        await repository.Add( result );

        var response = mapper.Map<ServiceRequest>( result );

        return response;
    }

    public async Task<EditStatus> UpdateStatus( Guid id, EditStatus request )
    {
        var result = await repository.FindBy( service => service.ServiceId == id).FirstOrDefaultAsync();

        if ( result is not null )
        {
            result.StateService = request.Status ?? result.StateService;

            await repository.Update( result );

            var response = mapper.Map<EditStatus>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ServiceNotFound );
        }
    }

    public async Task<ServiceRequest> UpdateService( Guid idService, ServiceRequest request )
    {
        var result = await repository.FindBy( service => service.ServiceId == idService).FirstOrDefaultAsync();

        if ( result is not null )
        {
            result.ClientId = request.IdClient;
            result.EmployeeId = request.IdEmployee;
            result.ServiceDate = request.ServiceDate ?? result.ServiceDate;
            result.Price = request.Price ?? result.Price;
            result.StateService = request.Status ?? result.StateService;

            await repository.Update(result);

            var response = mapper.Map<ServiceRequest>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ServiceNotFound );
        }
    }

    public async Task<ServiceRequest> DeleteService( Guid idService )
    {
        var result = await repository.FindBy( service => service.ServiceId == idService ).FirstOrDefaultAsync();

        if ( result is not null ) 
        {
            try
            {
                await repository.Delete( result );

                var response = mapper.Map<ServiceRequest>( result );

                return response;
            }
            catch (Exception)
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.RelatedService );
            }
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ServiceNotFound );
        }
    }
}
