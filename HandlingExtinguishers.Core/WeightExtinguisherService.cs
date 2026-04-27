namespace HandlingExtinguishers.Core.Services;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Extinguishers;
using HandlingExtinguishers.Models.Models;
using Microsoft.EntityFrameworkCore;
#endregion

public class WeightExtinguisherService( IBaseRepository<WeightExtinguisher> repository, IMapper mapper ) : IWeightExtinguisherService
{
    private readonly IBaseRepository<WeightExtinguisher> repository = repository;
    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<WightExtinguisherRequest>> SearchWeightExtinguishers()
    {
        var result = await repository.GetAll().ToListAsync();

        var response = mapper.Map<IEnumerable<WightExtinguisherRequest>>( result );

        return response;
    }

    public async Task<WightExtinguisherRequest> SearchWeightExtinguisherById( Guid idWeightExtinguisher )
    {
        var result = await repository.FindBy( weight => weight.WeightExtinguisherId == idWeightExtinguisher ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            return mapper.Map<WightExtinguisherRequest>( result ); ;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.WeightNotFound );
        }
    }

    public async Task<WightExtinguisherRequest> CreateWeightExtinguisher( WightExtinguisherRequest weightExtinguisher )
    {
        var result = mapper.Map<WeightExtinguisher>( weightExtinguisher );

        await repository.Add( result );

        var response = mapper.Map<WightExtinguisherRequest>( result );

        return response;
    }

    public async Task<WightExtinguisherRequest> UpdateWeightExtinguisher( Guid weightExtinguisherId, WightExtinguisherRequest request )
    {
        var result = await repository.FindBy( weight => weight.WeightExtinguisherId == weightExtinguisherId ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            result.WeightPound = request.WeightInPounds;

            await repository.Update( result );

            var response = mapper.Map<WightExtinguisherRequest>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.WeightNotFound );
        }
    }


    public async Task<WightExtinguisherRequest> DeleteWeightExtinguisher( Guid idWeightExtinguisher )
    {
        var weightExtinguisher = await repository.FindBy( weight => weight.WeightExtinguisherId == idWeightExtinguisher ).FirstOrDefaultAsync();

        if ( weightExtinguisher is not null )
        {
            try
            {
                await repository.Delete(weightExtinguisher);

                var result = mapper.Map<WightExtinguisherRequest>(weightExtinguisher);

                return result;
            }
            catch (Exception)
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.RelatedWeight );
            }
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.WeightNotFound );
        }
    }

}
