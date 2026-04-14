namespace HandlingExtinguishers.Core.Services;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.Models.Pagination;
using HandlingFireExtinguisher.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using WebApplicationFacturas.Helpers;
#endregion

public class ServiceEmployee( IRepositoryEmployee repositoryEmployee, IMapper mapper ) : IEmployeeService
{
    private readonly IMapper mapper = mapper;
    private readonly IRepositoryEmployee repositoryEmployee = repositoryEmployee;

    public async Task<FilterEmployeeResponseDto> SearchEmployees( QueryParameter filter )
    {
        try
        {
            var response = new FilterEmployeeResponseDto();

            var search = repositoryEmployee.FindByAsNoTracking(x => x.Active);

            if ( filter.OrderBy == "Id" ) filter.OrderBy = "Name";

            if ( !string.IsNullOrEmpty( filter.Search ) )
            {
                search = search.Where( employee => employee.FirstName!.ToLower().Contains( filter.Search ) || employee.LastName!.ToLower().Contains( filter.Search ) );
            }

            var pagegResult = await search.PaginateAsync( filter );

            var result = mapper.Map<List<EmployeeBaseResponseDto>>( pagegResult.Resource );

            response.Employees = PaginationHelper.CreatePagedReponse<EmployeeBaseResponseDto>( result, filter, pagegResult.TotalRecords );

            return response;
        }
        catch ( Exception )
        {
            throw;
        }
    }

    public async Task<EmployeeResponseDto> SearchEmployeeById( Guid idEmployee )
    {
        try
        {
            var result = await repositoryEmployee.FindBy( employee => employee.Id == idEmployee ).Include( company => company.Company ).FirstOrDefaultAsync();

            if ( result is not null )
            {
                return mapper.Map<EmployeeResponseDto>(result);
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

    public async Task<EmployeeBaseResponseDto> CreateEmployee( EmployeeRequestDto request )
    {
        try
        {
            var employee = mapper.Map<Employee>( request );

            employee.Active = true;

            await repositoryEmployee.Add( employee );

            var response = mapper.Map<EmployeeBaseResponseDto>( request );

            return response;
        }
        catch ( Exception )
        {
            throw;
        }
    }

    public async Task<EmployeeResponseDto> UpdatedEmployee( Guid employeeId, PatchEmployeeRequestDto request )
    {
        try
        {
            var search = await repositoryEmployee.FindBy( employee => employee.Id == employeeId ).FirstOrDefaultAsync();

            if ( search is not null )
            {
                var properties = new UpdateMapperProperties<Employee, PatchEmployeeRequestDto>();

                var result = await properties.MapperUpdate( search!, request );

                if ( request.Active.HasValue )
                {
                    result.Active = request.Active.Value;
                }
                else
                {
                    result.Active = search.Active;
                }

                await repositoryEmployee.Patch( search );

                var response = mapper.Map<EmployeeResponseDto>( search );

                return response;
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

    public async Task<bool> DeleteEmployee( Guid employeeId )
    {

        var result = await repositoryEmployee.FindBy(employee => employee.Id == employeeId).FirstOrDefaultAsync();

        if (result is not null)
        {
            await repositoryEmployee.Delete( result );

            return true;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.EmployeeNotFound );
        }
    }
}
