namespace HandlingExtinguishers.Contracts.Interfaces.QueryServices;

using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Services;

public interface IDetailServiceQueryService
{
    Task<List<DetailServiceResponse>> SearchDetailsService(FilterDetailService filter);

    public Task<DetailServiceResponse> GetDetailServiceById(Guid detailId);
}
