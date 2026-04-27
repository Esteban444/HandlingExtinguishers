using HandlingExtinguishers.Models.Employees;

namespace HandlingExtinguishers.Models.Company;

public class CompanyResponse
{
    public Guid CompanyId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Description { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Nit { get; set; }

    public bool? Active { get; set; }

    public List<EmployeeResponse>? Employees { get; set; }
}
