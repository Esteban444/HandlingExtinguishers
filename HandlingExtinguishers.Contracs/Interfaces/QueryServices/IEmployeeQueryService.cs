namespace HandlingExtinguishers.Contracts.Interfaces.QueryServices;

#region Usings
using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Pagination;
# endregion

public interface IEmployeeQueryService
{
    Task<FilterEmployeeResponse> SearchEmployees( QueryParameter filter );

    Task<EmployeeResponse> SearchEmployeeById( Guid employeeId );
}
