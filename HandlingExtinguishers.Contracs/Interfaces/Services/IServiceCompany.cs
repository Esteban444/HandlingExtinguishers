using HandlingExtinguishers.Dto.Pagination;
using HandlingExtinguishers.Models.Company;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServiceCompany
    {
        Task<FilterCompanyResponseDto> GetCompanies(QueryParameter filter);
        Task<FilterCompanyResponseDto> GetCompaniesDisabled(QueryParameter filter);
        Task<CompanyResponseDto> GetCompany(Guid companyId);
        Task<CompanyRequestDto> CreateCompany(CompanyRequestDto company);
        Task<CompanyRequestDto> UpdateFieldsCompany(Guid companyId, PatchCompanyRequestDto companyBase);
        Task<bool> DeleteCompany(Guid companyId);
    }
}