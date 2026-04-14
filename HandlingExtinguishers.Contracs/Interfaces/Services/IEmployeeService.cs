using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Pagination;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<FilterEmployeeResponseDto> SearchEmployees( QueryParameter filter );
        Task<EmployeeResponseDto> SearchEmployeeById( Guid idEmployee );
        Task<EmployeeBaseResponseDto> CreateEmployee( EmployeeRequestDto request ); 
        Task<EmployeeResponseDto> UpdatedEmployee( Guid idEmployee, PatchEmployeeRequestDto request );
        Task<bool> DeleteEmployee( Guid idEmployee );
    }
}
