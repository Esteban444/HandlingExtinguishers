using HandlingExtinguishers.Dto.Company;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IServiceCompany
    {
        Task<IEnumerable<CompanyResponseDto>> GetCompanies();
        Task<CompanyResponseDto> GetCompany(Guid companyId);
        Task<CompanyBase> CreateCompany(CompanyBase company);
        Task<CompanyBase> UpdateCompany(Guid companyId, CompanyBase companyBase);
        Task<CompanyResponseDto> DeleteCompany(Guid companyId);
    }
}