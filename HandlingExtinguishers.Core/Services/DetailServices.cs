namespace HandlingExtinguishers.Core.Services;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.Models.Services;
using Microsoft.EntityFrameworkCore;
#endregion

public class DetailServices( IRepositoryDetailService repository, IMapper mapper ) : IDetailService
{
    private readonly IMapper mapper = mapper;
    private readonly IRepositoryDetailService repository = repository;

    public async Task<List<DetalleServicioDTO>> SearchDetailsService( FilterDetailService filter )
    {
        var details = await repository.GetAll().ToArrayAsync();

        var results = mapper.Map<List<DetalleServicioDTO>>( details );

        return results;
    }

    public async Task<DetalleServicioDTO> GetDetailServiceById( Guid idDetail )
    {
        var detail = await repository.FindBy( detail => detail.DetailServiceId == idDetail ).FirstOrDefaultAsync();

        if ( detail is not null )
        {
            return mapper.Map<DetalleServicioDTO>( detail );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.DetailServiceNotFound );
        }
    }

    public async Task<DetalleServicioBase> CreateDetailService( DetalleServicioBase detail )
    {
        var result = mapper.Map<DetailService>( detail );

        await repository.Add( result );

        var response = mapper.Map<DetalleServicioBase>( result );

        return response;
    }

    public async Task<DetalleServicioBase> UpdateDetailService( Guid idDetail, DetalleServicioBase detail )
    {
        var result = await repository.FindBy( detail => detail.DetailServiceId == idDetail ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            result.ServiceId = detail.IdServicios;
            result.Description = detail.Descripcion;
            result.TypeExtinguisherId = detail.IdTipoExtintor;
            result.WeightExtinguisherId = detail.IdPesoExtintor;
            result.Price = detail.Valor;
            result.Quantity = detail.Cantidad;
            result.Total = detail.Total;

            await repository.Update( result );

            var response = mapper.Map<DetalleServicioBase>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.DetailServiceNotFound );
        }
    }

    public async Task<DetalleServicioDTO> DeleteDetailService( Guid idDetail )
    {
        var result = await repository.FindBy( detail => detail.DetailServiceId == idDetail ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            try
            {
                await repository.Delete(result);

                var response = mapper.Map<DetalleServicioDTO>( result );

                return response;
            }
            catch ( Exception )
            {

                throw new HandlingExceptions( HandlingExtinguisherResources.RelatedDetailService );
            }
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.DetailServiceNotFound );
        }
    }
}
