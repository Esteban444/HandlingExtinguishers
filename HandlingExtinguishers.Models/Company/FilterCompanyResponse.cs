namespace HandlingExtinguishers.Models.Company;

using HandlingExtinguishers.Models.Pagination;

public class FilterCompanyResponse
{
    public PagedResponse<IEnumerable<CompanyResponse>>? Companies { get; set; }
}
