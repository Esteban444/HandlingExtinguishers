namespace HandlingExtinguishers.Contracts.Interfaces.Services;

#region Usings
using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Pagination;
#endregion

public interface IEmployeeService
{
    Task<FilterEmployeeResponse> SearchEmployees( QueryParameter filter );

    Task<EmployeeResponse> SearchEmployeeById( Guid employeeId );

    Task<EmployeeResponse> CreateEmployee( EmployeeRequest request ); 

    Task<EmployeeResponse> UpdatedEmployee( Guid employeeId, EmployeeRequest request );

    Task<bool> DeleteEmployee( Guid employeeId );
}
