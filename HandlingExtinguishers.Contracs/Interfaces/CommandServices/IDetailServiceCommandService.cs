namespace HandlingExtinguishers.Contracts.Interfaces.CommandServices;

using HandlingExtinguishers.Models.Services;

public interface IDetailServiceCommandService
{
    Task<DetailServiceResponse> CreateDetailService(DetailServiceRequest request);

    Task<DetailServiceResponse> UpdateDetailService(Guid detailId, DetailServiceRequest request);

    Task<DetailServiceResponse> DeleteDetailService(Guid detailId);
}
