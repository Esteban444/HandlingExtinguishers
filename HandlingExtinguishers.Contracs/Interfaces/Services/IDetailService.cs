namespace HandlingExtinguishers.Contracts.Interfaces.Services;

#region Usings
using ManagementFireEstinguisher.Dto.Services;
using ManejoExtintores.Core.Filtros_Busqueda;
#endregion

public interface IDetailService
{
    Task<List<DetalleServicioDTO>> SearchDetailsService( FiltroDetalleServicio filter );
    public Task<DetalleServicioDTO> GetDetailServiceById( Guid idDetail );
    Task<DetalleServicioBase> CreateDetailService( DetalleServicioBase detail );
    Task<DetalleServicioBase> UpdateDetailService( Guid idDetail, DetalleServicioBase detail );
    Task<DetalleServicioDTO> DeleteDetailService( Guid idDetail ); 
}
