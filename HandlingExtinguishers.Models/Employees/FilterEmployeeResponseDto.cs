using HandlingExtinguishers.Models.Pagination;

namespace HandlingExtinguishers.Models.Employees
{
    public class FilterEmployeeResponseDto
    {
        public PagedResponse<IEnumerable<EmployeeBaseResponseDto>>? Employees { get; set; }
    }
}
