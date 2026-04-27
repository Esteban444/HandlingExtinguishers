namespace HandlingExtinguishers.Contracts.Interfaces.QueryServices;

#region Usings
using HandlingExtinguishers.Models.Company;
using HandlingExtinguishers.Models.Pagination;
#endregion

public interface ICompanyQueryService
{
    Task<FilterCompanyResponse> SearchCompanies( QueryParameter filter );

    Task<FilterCompanyResponse> SearchCompaniesDisabled( QueryParameter filter );

    Task<CompanyResponse> SearchCompany( Guid companyId );
}