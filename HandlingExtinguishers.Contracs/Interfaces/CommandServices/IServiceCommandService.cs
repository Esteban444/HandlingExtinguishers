namespace HandlingExtinguishers.Contracts.Interfaces.CommandServices;

#region Usings
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Services;
# endregion

public interface IServiceCommandService
{

    Task<ServiceResponse> CreateService( ServiceRequest request );

    Task<EditStatus> UpdateStatus( Guid serviceId, EditStatus request );

    Task<ServiceResponse> UpdateService( Guid serviceId, ServiceRequest request );

    Task<ServiceResponse> DeleteService( Guid serviceId );
}
