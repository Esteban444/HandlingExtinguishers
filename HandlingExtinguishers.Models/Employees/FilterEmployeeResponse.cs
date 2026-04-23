namespace HandlingExtinguishers.Models.Employees;

using HandlingExtinguishers.Models.Pagination;

public class FilterEmployeeResponse
{
    public PagedResponse<IEnumerable<EmployeeBaseResponse>>? Employees { get; set; }
}
