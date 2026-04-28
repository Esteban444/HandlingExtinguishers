namespace HandlingExtinguishers.Contracts.Interfaces.CommandServices;

using HandlingExtinguishers.Models.Employees;

public interface IEmployeeCommandService
{
    Task<EmployeeResponse> CreateEmployee( EmployeeRequest request );

    Task<EmployeeResponse> UpdatedEmployee( Guid employeeId, EmployeeRequest request );

    Task<bool> DeleteEmployee( Guid employeeId );
}
