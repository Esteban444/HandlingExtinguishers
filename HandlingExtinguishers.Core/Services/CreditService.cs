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

public class CreditService( IRepositoryCredit repository, IMapper mapper ) : ICreditService
{
    private readonly IRepositoryCredit repository = repository;
    private readonly IMapper mapper = mapper;

    public async Task<List<CreditServiceRequest>> SearchCredits( FilterCredit filters )
    {
        var credits = await repository.GetAll().ToListAsync();

        var response = mapper.Map<List<CreditServiceRequest>>( credits );

        return response;
    }

    public async Task<CreditServiceRequest> SearchCreditById( Guid idCredit )
    {
        var result = await repository.FindBy( credit => credit.CreditServiceId == idCredit ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            return mapper.Map<CreditServiceRequest>( result );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.CreditNotFound );
        }
    }

    public async Task<CreditServiceRequest> CreateCredit( CreditServiceRequest credit )
    {
        var result = mapper.Map<Models.Models.CreditService>( credit );

        await repository.Add( result );

        var response = mapper.Map<CreditServiceRequest>( result );

        return response;
    }

    public async Task<CreditServiceRequest> UpdateCredit( Guid id, CreditServiceRequest credit )
    {
        var result = await repository.FindBy(x => x.CreditServiceId == id).FirstOrDefaultAsync();

        if ( result is not null )
        {
            result.ServiceId = credit.IdService;
            result.Advances = credit.Advances;
            result.Debt = credit.Debt;
            result.Date = credit.Date;

            await repository.Update( result );

            var response = mapper.Map<CreditServiceRequest>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.CreditNotFound );
        }
    }

    public async Task<CreditServiceRequest> DeleteCredit( Guid idCredit )
    {
        var result = await repository.FindBy( credit => credit.ServiceId == idCredit).FirstOrDefaultAsync();

        if ( result is not null )
        {
            try
            {
                await repository.Delete( result );

                var response = mapper.Map<CreditServiceRequest>( result );

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
