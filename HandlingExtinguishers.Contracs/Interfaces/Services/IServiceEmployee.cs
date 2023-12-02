using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Pagination;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServiceEmployee
    {
        Task<FilterEmployeeResponseDto> SearchEmployees(QueryParameter filter);
        Task<EmployeeResponseDto> SearchEmployeeById(Guid id);
        Task<EmployeeBaseResponseDto> AddEmployee(EmployeeRequestDto Request);
        Task<EmployeeResponseDto> UpdatedFieldEmployee(Guid id, PatchEmployeeRequestDto request);
        Task<bool> DeleteEmployee(Guid id);
    }
}
