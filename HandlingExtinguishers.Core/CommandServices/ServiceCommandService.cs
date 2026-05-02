namespace HandlingExtinguishers.Core.CommandServices;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.CommandServices;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.Models.Services;
using Microsoft.EntityFrameworkCore;
# endregion

public class ServiceCommandService( IServiceRepository repository,IMapper mapper ) : IServiceCommandService
{
    private readonly IServiceRepository repository = repository;

    private readonly IMapper mapper = mapper;

    public async Task<ServiceResponse> CreateService( ServiceRequest request )
    {
        try
        {
            var result = mapper.Map<Service>( request );

            await repository.Add( result );

            var response = mapper.Map<ServiceResponse>( result );

            return response;
        }
        catch ( Exception )
        {

            throw;
        }
    }

    public async Task<EditStatus> UpdateStatus( Guid serviceId, EditStatus request )
    {
        try
        {
            var result = await repository.FindBy( service => service.ServiceId == serviceId ).FirstOrDefaultAsync();

            if ( result is not null )
            {
                result.Update( result.ClientId, result.EmployeeId, result.ServiceDate, result.Price, request.Status, result.ExpirationDate, result.MaintenenceDate, result.Advance, true );

                await repository.Update( result );

                var response = mapper.Map<EditStatus>( result );

                return response;
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.ServiceNotFound );
            }
        }
        catch ( Exception )
        {
            throw;
        }
    }

    public async Task<ServiceResponse> UpdateService( Guid serviceId, ServiceRequest request )
    {
        try
        {
            var result = await repository.FindBy( service => service.ServiceId == serviceId ).FirstOrDefaultAsync();

            if ( result is not null )
            {
                result.Update( request.ClientId, request.EmployeeId, request.ServiceDate, request.Price, request.StateService, request.ExpirationDate, request.MaintenenceDate, request.Advance, true );

                await repository.Update( result );

                var response = mapper.Map<ServiceResponse>( result );

                return response;
            }
            else
            {
                throw new HandlingExceptions(HandlingExtinguisherResources.ServiceNotFound);
            }
        }
        catch ( Exception )
        {

            throw;
        }
        
    }

    public async Task<ServiceResponse> DeleteService( Guid idService )
    {
        var result = await repository.FindBy( service => service.ServiceId == idService ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            try
            {
                result.Deactivate();

                await repository.Update( result );

                var response = mapper.Map<ServiceResponse>( result );

                return response;
            }
            catch ( Exception )
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
