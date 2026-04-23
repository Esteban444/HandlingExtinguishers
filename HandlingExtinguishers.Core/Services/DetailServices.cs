namespace HandlingExtinguishers.Core.Services;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.Models.Services;
using Microsoft.EntityFrameworkCore;
#endregion

public class DetailServices( IDetailServiceRepository repository, IMapper mapper ) : IDetailService
{
    private readonly IMapper mapper = mapper;
    private readonly IDetailServiceRepository repository = repository;

    public async Task<List<DetailServiceResponse>> SearchDetailsService( FilterDetailService filter )
    {
        var details = await repository.GetAll().ToArrayAsync();

        var results = mapper.Map<List<DetailServiceResponse>>( details );

        return results;
    }

    public async Task<DetailServiceResponse> GetDetailServiceById( Guid detailId )
    {
        var detail = await repository.FindBy( detail => detail.DetailServiceId == detailId ).FirstOrDefaultAsync();

        if ( detail is not null )
        {
            return mapper.Map<DetailServiceResponse>( detail );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.DetailServiceNotFound );
        }
    }

    public async Task<DetailServiceResponse> CreateDetailService( DetailServiceRequest detail )
    {
        var result = mapper.Map<DetailService>( detail );

        await repository.Add( result );

        var response = mapper.Map<DetailServiceResponse>( result );

        return response;
    }

    public async Task<DetailServiceResponse> UpdateDetailService( Guid idDetail, DetailServiceRequest detail )
    {
        var result = await repository.FindBy( detail => detail.DetailServiceId == idDetail ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            result.ServiceId = detail.ServiceId;
            result.Description = detail.Description;
            result.TypeExtinguisherId = detail.TypeExtinguisherId;
            result.WeightExtinguisherId = detail.WeightExtinguisherId;
            result.Price = detail.Value;
            result.Quantity = detail.Quantity;
            result.Total = detail.Total;

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
                await repository.Delete(result);

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
