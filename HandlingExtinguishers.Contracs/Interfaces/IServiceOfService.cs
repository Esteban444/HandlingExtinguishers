namespace HandlingExtinguishers.Contracts.Interfaces;

#region Usings
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Services;
#endregion

public interface IServiceOfService
{
    Task<IEnumerable<ServiceRequest>> SearchServices( FilterService filters );

    Task<ServiceRequest> SearchServiceById( Guid serviceId );

    Task<ServiceRequest> CreateService( ServiceRequest request );

    Task<ServiceRequest> CreateServiceDetail( ServiceRequest request );

    Task<EditStatus> UpdateStatus( Guid serviceId, EditStatus request );

    Task<ServiceRequest> UpdateService(Guid serviceId, ServiceRequest request );

    Task<ServiceRequest> DeleteService( Guid serviceId );
}
