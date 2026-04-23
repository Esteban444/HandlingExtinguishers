using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Pagination;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<FilterEmployeeResponse> SearchEmployees( QueryParameter filter );
        Task<EmployeeResponse> SearchEmployeeById( Guid idEmployee );
        Task<EmployeeBaseResponse> CreateEmployee( EmployeeRequest request ); 
        Task<EmployeeResponse> UpdatedEmployee( Guid idEmployee, PatchEmployeeRequest request );
        Task<bool> DeleteEmployee( Guid idEmployee );
    }
}
