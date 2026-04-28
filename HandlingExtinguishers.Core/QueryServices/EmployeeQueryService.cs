namespace HandlingExtinguishers.Core.QueryServices;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.QueryServices;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Pagination;
using Microsoft.EntityFrameworkCore;
#endregion

public class EmployeeQueryService( IEmployeeRepository repositoryEmployee, IMapper mapper ) : IEmployeeQueryService
{
    private readonly IEmployeeRepository repositoryEmployee = repositoryEmployee;
    private readonly IMapper mapper = mapper;

    public async Task<FilterEmployeeResponse> SearchEmployees(QueryParameter filter)
    {
        try
        {
            var response = new FilterEmployeeResponse();

            var search = repositoryEmployee.FindByAsNoTracking( x => x.Active );

            if ( filter.OrderBy == CommonConstants.EmployeeIdPropertyName ) filter.OrderBy = CommonConstants.EmployeePropertyName;

            if ( !string.IsNullOrEmpty( filter.Search ) )
            {
                search = search.Where( employee => employee.FirstName!.ToLower().Contains(filter.Search) || employee.LastName!.ToLower().Contains( filter.Search ) );
            }

            var pagegResult = await search.PaginateAsync( filter );

            var result = mapper.Map<List<EmployeeResponse>>( pagegResult.Resource );

            response.Employees = PaginationHelper.CreatePagedReponse<EmployeeResponse>( result, filter, pagegResult.TotalRecords );

            return response;
        }
        catch ( Exception )
        {
            throw;
        }
    }

    public async Task<EmployeeResponse> SearchEmployeeById( Guid idEmployee )
    {
        try
        {
            var result = await repositoryEmployee.FindBy( employee => employee.EmployeeId == idEmployee && employee.Active ).FirstOrDefaultAsync();

            if (  result is not null)
            {
                return mapper.Map<EmployeeResponse>( result );
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.EmployeeNotFound );
            }
        }
        catch ( Exception )
        {
            throw;
        }
    }
}
