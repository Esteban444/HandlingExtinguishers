namespace HandlingExtinguishers.Core.CommandServices;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.CommandServices;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Models;
using Microsoft.EntityFrameworkCore;
#endregion

public class EmployeeCommandService( IMapper mapper, IEmployeeRepository repositoryEmployee ) : IEmployeeCommandService
{
    private readonly IMapper mapper = mapper;
    private readonly IEmployeeRepository repositoryEmployee = repositoryEmployee;

    public async Task<EmployeeResponse> CreateEmployee( EmployeeRequest request )
    {
        try
        {
            var result = mapper.Map<Employee>( request );

            var employee = Employee.Create( result.CompanyId,
                                            result.FirstName,
                                            result.SecondName,
                                            result.LastName,
                                            result.SecondLastName,
                                            result.Address,
                                            result.Phone,
                                            result.Email,
                                            result.Active
            );

            await repositoryEmployee.Add( employee );

            var response = mapper.Map<EmployeeResponse>( request );

            return response;
        }
        catch ( Exception )
        {
            throw;
        }
    }

    public async Task<EmployeeResponse> UpdatedEmployee( Guid employeeId, EmployeeRequest request )
    {
        try
        {
            var search = await repositoryEmployee.FindBy( employee => employee.EmployeeId == employeeId ).FirstOrDefaultAsync();

            if ( search is not null )
            {
                var properties = new UpdateMapperProperties<Employee, EmployeeRequest>();

                var result = await properties.MapperUpdate( search!, request );

                result.Update( result.FirstName,
                               result.SecondName,
                               result.LastName,
                               result.SecondLastName,
                               result.Address,
                               result.Phone,
                               result.Email,
                               result.Active
                );

                await repositoryEmployee.Patch( result );

                var response = mapper.Map<EmployeeResponse>( result );

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
        try
        {
            var result = await repositoryEmployee.FindBy( employee => employee.EmployeeId == employeeId && employee.Active ).FirstOrDefaultAsync();

            if ( result is not null )
            {
                result.Deactivate();

                await repositoryEmployee.Patch( result );

                return true;
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.EmployeeNotFound);
            }
        }
        catch ( Exception )
        {

            throw;
        }
    }
}
