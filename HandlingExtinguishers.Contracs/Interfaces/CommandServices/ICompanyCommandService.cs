namespace HandlingExtinguishers.Contracts.Interfaces.CommandServices;

using HandlingExtinguishers.Models.Company;

public interface ICompanyCommandService
{
    Task<CompanyResponse> CreateCompany( CompanyRequest company );

    Task<CompanyResponse> UpdateCompany( Guid companyId, UpdateCompanyRequest request );

    Task<bool> DeleteCompany( Guid companyId );
}
