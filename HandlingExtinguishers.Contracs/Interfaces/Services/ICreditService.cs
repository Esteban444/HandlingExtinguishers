namespace HandlingExtinguishers.Contracts.Interfaces.Services;

using HandlingExtinguishers.Models.Credit;
using HandlingExtinguishers.Models.Filters;

public interface ICreditService
{
    Task<List<CreditServiceRequest>> SearchCredits(FilterCredit filters );
    Task<CreditServiceRequest> SearchCreditById( Guid idCredit );
    Task<CreditServiceRequest> CreateCredit( CreditServiceRequest credit );
    Task<CreditServiceRequest> UpdateCredit( Guid idCredit, CreditServiceRequest credit );
    Task<CreditServiceRequest> DeleteCredit( Guid idCredit );
}
