namespace HandlingExtinguishers.Core.Services;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Credit;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Models;
using Microsoft.EntityFrameworkCore;
#endregion

public class CreditService( ICreditServiceRepository repository, IMapper mapper ) : ICreditService
{
    private readonly ICreditServiceRepository repository = repository;
    private readonly IMapper mapper = mapper;

    public async Task<List<CreditServiceResponse>> SearchCredits( FilterCredit filters )
    {
        var credits = await repository.GetAll().ToListAsync();

        var response = mapper.Map<List<CreditServiceResponse>>( credits );

        return response;
    }

    public async Task<CreditServiceResponse> SearchCreditById( Guid creditId )
    {
        var result = await repository.FindBy( credit => credit.CreditServiceId == creditId ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            return mapper.Map<CreditServiceResponse>( result );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.CreditNotFound );
        }
    }

    public async Task<CreditServiceResponse> CreateCredit( CreditServiceRequest request )
    {
        var result = mapper.Map<Models.Models.CreditService>( request );

        await repository.Add( result );

        var response = mapper.Map<CreditServiceResponse>( result );

        return response;
    }

    public async Task<CreditServiceResponse> UpdateCredit( Guid id, CreditServiceRequest credit )
    {
        var result = await repository.FindBy(x => x.CreditServiceId == id).FirstOrDefaultAsync();

        if ( result is not null )
        {
            result.ServiceId = credit.IdService;
            result.Advances = credit.Advances;
            result.Debt = credit.Debt;
            result.Date = credit.Date;

            await repository.Update( result );

            var response = mapper.Map<CreditServiceResponse>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.CreditNotFound );
        }
    }

    public async Task<CreditServiceResponse> DeleteCredit( Guid idCredit )
    {
        var result = await repository.FindBy( credit => credit.ServiceId == idCredit).FirstOrDefaultAsync();

        if ( result is not null )
        {
            try
            {
                await repository.Delete( result );

                var response = mapper.Map<CreditServiceResponse>( result );

                return response;
            }
            catch (Exception)
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.RelatedCredit );
            }
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.CreditNotFound );
        }

    }
}
