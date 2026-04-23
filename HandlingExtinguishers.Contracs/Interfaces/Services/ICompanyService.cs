namespace HandlingExtinguishers.Contracts.Interfaces.Services;

#region Usings
using HandlingExtinguishers.Models.Pagination;
using HandlingExtinguishers.Models.Company;
#endregion

public interface ICompanyService
{
    Task<FilterCompanyResponse> SearchCompanies( QueryParameter filter );
    Task<FilterCompanyResponse> SearchCompaniesDisabled( QueryParameter filter );
    Task<CompanyResponse> SearchCompany( Guid companyId );
    Task<CompanyRequest> CreateCompany( CompanyRequest company );
    Task<CompanyRequest> UpdateCompany( Guid companyId, PatchCompanyRequest companyBase ); 
    Task<bool> DeleteCompany( Guid companyId );
}