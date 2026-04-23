namespace HandlingExtinguishers.Models.Employees;

using HandlingExtinguishers.Models.Pagination;

public class FilterEmployeeResponse
{
    public PagedResponse<IEnumerable<EmployeeResponse>>? Employees { get; set; }
}
