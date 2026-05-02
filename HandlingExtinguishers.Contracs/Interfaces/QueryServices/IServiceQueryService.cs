namespace HandlingExtinguishers.Contracts.Interfaces.QueryServices;

#region Usings
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Services;
# endregion

public interface IServiceQueryService
{
    Task<IEnumerable<ServiceResponse>> SearchServices( FilterService filters );

    Task<ServiceResponse> SearchServiceById( Guid serviceId );
}
