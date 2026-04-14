namespace HandlingExtinguishers.Contracts.Interfaces.Services;

#region Usings
using HandlingExtinguishers.Models.Pagination;
using HandlingExtinguishers.Models.Company;
#endregion

public interface ICompanyService
{
    Task<FilterCompanyResponseDto> SearchCompanies( QueryParameter filter );
    Task<FilterCompanyResponseDto> SearchCompaniesDisabled( QueryParameter filter );
    Task<CompanyResponseDto> SearchCompany( Guid companyId );
    Task<CompanyRequestDto> CreateCompany( CompanyRequestDto company );
    Task<CompanyRequestDto> UpdateCompany( Guid companyId, PatchCompanyRequestDto companyBase ); 
    Task<bool> DeleteCompany( Guid companyId );
}