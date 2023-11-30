using HandlingExtinguishers.Dto.Company;
using HandlingExtinguishers.Dto.Pagination;
using HandlingExtinguishers.Models.Company;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServiceCompany
    {
        Task<FilterCompanyResponseDto> GetCompanies(QueryParameter filter);
        Task<CompanyResponseDto> GetCompany(Guid companyId);
        Task<CompanyBase> CreateCompany(CompanyBase company);
        Task<CompanyBase> UpdateCompany(Guid companyId, CompanyBase companyBase);
        Task<CompanyResponseDto> DeleteCompany(Guid companyId);
    }
}