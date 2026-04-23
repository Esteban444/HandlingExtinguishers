namespace HandlingExtinguishers.Contracts.Interfaces.Services;

using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Services;

#region Usings
#endregion

public interface IDetailService
{
    Task<List<DetalleServicioDTO>> SearchDetailsService( FilterDetailService filter );
    public Task<DetalleServicioDTO> GetDetailServiceById( Guid idDetail );
    Task<DetalleServicioBase> CreateDetailService( DetalleServicioBase detail );
    Task<DetalleServicioBase> UpdateDetailService( Guid idDetail, DetalleServicioBase detail );
    Task<DetalleServicioDTO> DeleteDetailService( Guid idDetail ); 
}
