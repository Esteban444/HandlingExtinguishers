namespace HandlingExtinguishers.Core.QueryServices;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.QueryServices;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Services;
using Microsoft.EntityFrameworkCore;
#endregion

public class DetailServiceQueryService( IDetailServiceRepository repository, IMapper mapper ): IDetailServiceQueryService
{
    private readonly IMapper mapper = mapper;
    private readonly IDetailServiceRepository repository = repository;

    public async Task<List<DetailServiceResponse>> SearchDetailsService( FilterDetailService filter )
    {
        var results = await repository.GetAll().ToArrayAsync();

        var response = mapper.Map<List<DetailServiceResponse>>( results );

        return response;
    }

    public async Task<DetailServiceResponse> GetDetailServiceById( Guid detailId )
    {
        var result = await repository.FindBy( detail => detail.DetailServiceId == detailId ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            return mapper.Map<DetailServiceResponse>( result );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.DetailServiceNotFound );
        }
    }
}
