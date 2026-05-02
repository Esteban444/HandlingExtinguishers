namespace HandlingExtinguishers.Core.QueryServices;

using AutoMapper;

#region Usings
using HandlingExtinguishers.Contracts.Interfaces.QueryServices;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
#endregion

public class ServiceQueryService( IServiceRepository repository,IMapper mapper ): IServiceQueryService
{
    private readonly IServiceRepository repository = repository;

    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<ServiceResponse>> SearchServices( [FromQuery] FilterService filter )
    {
        try
        {
            var result = await repository.GetAll().ToListAsync();

            var response = mapper.Map<IEnumerable<ServiceResponse>>( result );

            return response;
        }
        catch ( Exception )
        {
            throw;
        }
    }

    public async Task<ServiceResponse> SearchServiceById(Guid serviceId)
    {
        try
        {
            var result = await repository.FindBy( service => service.ServiceId == serviceId ).FirstOrDefaultAsync();

            if ( result is not null )
            {
                return mapper.Map<ServiceResponse>( result );
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
}
