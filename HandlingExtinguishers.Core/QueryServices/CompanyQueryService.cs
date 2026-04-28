namespace HandlingExtinguishers.Core.QueryServices;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.QueryServices;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Strategies;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Core.Strategis;
using HandlingExtinguishers.Models.Company;
using HandlingExtinguishers.Models.Pagination;
using Microsoft.EntityFrameworkCore;
#endregion

public class CompanyQueryService( ICompanyRepository repository,
                                  IMapper mapper ) : ICompanyQueryService
{
    private async Task<FilterCompanyResponse> ExecuteSearch( ICompanySearchStrategy strategy, QueryParameter filter )
    {
        var baseQuery = repository.FindByAsNoTracking( company => company.Active ).Include( employee => employee.Employees!.Where( employee => employee.Active ) );

        var filtered = strategy.Apply( baseQuery, filter );

        var paged = await filtered.PaginateAsync( filter );

        var result = mapper.Map<List<CompanyResponse>>( paged.Resource );

        return new FilterCompanyResponse
        {
            Companies = PaginationHelper.CreatePagedReponse( result, filter, paged.TotalRecords )
        };
    }

    public Task<FilterCompanyResponse> SearchCompanies( QueryParameter filter )
    {
        var strategy = string.IsNullOrEmpty( filter.Search )
            ? ( ICompanySearchStrategy )new ActiveCompaniesStrategy()
            : new FilteredCompaniesStrategy();

        return ExecuteSearch( strategy, filter );
    }

    public Task<FilterCompanyResponse> SearchCompaniesDisabled( QueryParameter filter ) =>
        ExecuteSearch( new DisabledCompaniesStrategy(), filter );

    public async Task<CompanyResponse> SearchCompany( Guid companyId )
    {
        var result = await repository
            .FindByAsNoTracking( company => company.Active && company.CompanyId == companyId ).FirstOrDefaultAsync();

        return result is not null
            ? mapper.Map<CompanyResponse>( result )
            : throw new HandlingExceptions( HandlingExtinguisherResources.CompanyNotFound );
    }
}
