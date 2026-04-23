namespace HandlingExtinguishers.Contracts.Interfaces.Services;

#region Usings
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Services;
#endregion

public interface IDetailService
{
    Task<List<DetailServiceResponse>> SearchDetailsService( FilterDetailService filter );

    public Task<DetailServiceResponse> GetDetailServiceById( Guid detailId );

    Task<DetailServiceResponse> CreateDetailService( DetailServiceRequest request );

    Task<DetailServiceResponse> UpdateDetailService( Guid detailId, DetailServiceRequest request );

    Task<DetailServiceResponse> DeleteDetailService( Guid detailId ); 
}
