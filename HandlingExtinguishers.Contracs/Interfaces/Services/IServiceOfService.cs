using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Services;
using ManagementFireEstinguisher.Dto;

namespace HandlingExtinguishers.Contracts.Interfaces.Services 
{
    public interface IServiceOfService
    {
        Task<IEnumerable<ServiceRequest>> SearchServices( FilterService filters );
        Task<ServiceRequest> SearchServiceById( Guid idService );
        Task<ServiceRequest> CreateService( ServiceRequest request );
        Task<ServiceRequest> CreateServiceDetail( ServiceRequest request );
        Task<EditStatus> UpdateStatus( Guid idService, EditStatus request );
        Task<ServiceRequest> UpdateService(Guid idService, ServiceRequest request );
        Task<ServiceRequest> DeleteService( Guid idService );
    }
}
