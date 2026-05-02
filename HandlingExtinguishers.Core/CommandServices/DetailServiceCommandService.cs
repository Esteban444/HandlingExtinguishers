namespace HandlingExtinguishers.Core.CommandServices;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.CommandServices;
using HandlingExtinguishers.Models.Services;
using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
#endregion

public class DetailServiceCommandService( IDetailServiceRepository repository, IMapper mapper ) : IDetailServiceCommandService
{
    private readonly IMapper mapper = mapper;
    private readonly IDetailServiceRepository repository = repository;

    public async Task<DetailServiceResponse> CreateDetailService( DetailServiceRequest request )
    {

        var result = mapper.Map<DetailService>( request );

        result.Create( request.ServiceId, 
                       request.Description, 
                       request.TypeExtinguisherId, 
                       request.WeightExtinguisherId, 
                       request.Price, 
                       request.Quantity,
                       request.Total );

        await repository.Add( result );

        var response = mapper.Map<DetailServiceResponse>( result );

        return response;
    }

    public async Task<DetailServiceResponse> UpdateDetailService( Guid detailId, DetailServiceRequest request )
    {
        var result = await repository.FindBy( detail => detail.DetailServiceId == detailId ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            result.Update( request.ServiceId, 
                           request.Description, 
                           request.TypeExtinguisherId, 
                           request.WeightExtinguisherId, 
                           request.Price, 
                           request.Quantity, 
                           request.Total );

            await repository.Update( result );

            var response = mapper.Map<DetailServiceResponse>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.DetailServiceNotFound );
        }
    }

    public async Task<DetailServiceResponse> DeleteDetailService( Guid detailId ) 
    {
        var result = await repository.FindBy( detail => detail.DetailServiceId == detailId ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            try
            {
                await repository.Delete( result );

                var response = mapper.Map<DetailServiceResponse>( result );

                return response;
            }
            catch ( Exception )
            {

                throw new HandlingExceptions( HandlingExtinguisherResources.RelatedDetailService );
            }
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.DetailServiceNotFound );
        }
    }
}
