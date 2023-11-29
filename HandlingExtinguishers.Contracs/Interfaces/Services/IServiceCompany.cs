using HandlingExtinguishers.Dto.Company;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServiceCompany
    {
        Task<IEnumerable<CompanyDto>> GetCompanies();
        Task<CompanyDto> GetCompany(Guid companyId);
        Task<CompanyBase> CreateCompany(CompanyBase company);
        Task<CompanyBase> UpdateCompany(Guid companyId, CompanyBase companyBase);
        Task<CompanyDto> DeleteCompany(Guid companyId);
    }
}