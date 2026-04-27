namespace HandlingExtinguishers.Contracts.Interfaces;

using HandlingExtinguishers.Models.Credit;
using HandlingExtinguishers.Models.Filters;

public interface ICreditService
{
    Task<List<CreditServiceResponse>> SearchCredits( FilterCredit filters );

    Task<CreditServiceResponse> SearchCreditById( Guid creditId );

    Task<CreditServiceResponse> CreateCredit( CreditServiceRequest request );

    Task<CreditServiceResponse> UpdateCredit( Guid creditId, CreditServiceRequest request );

    Task<CreditServiceResponse> DeleteCredit( Guid creditId );
}
