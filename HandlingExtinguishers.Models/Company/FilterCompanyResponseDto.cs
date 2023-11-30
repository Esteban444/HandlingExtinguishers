using HandlingExtinguishers.Dto.Company;
using HandlingExtinguishers.Dto.Pagination;

namespace HandlingExtinguishers.Models.Company
{
    public class FilterCompanyResponseDto
    {
        public PagedResponse<IEnumerable<CompanyResponseDto>>? Companies { get; set; }
    }
}
