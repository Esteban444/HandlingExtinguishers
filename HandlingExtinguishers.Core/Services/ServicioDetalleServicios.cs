using AutoMapper;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models.Models;
using ManagementFireEstinguisher.Dto.Services;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Net;

namespace ManejoExtintores.Core.Servicios
{
    public class ServicioDetalleServicios : IDetailService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryDetailService _repositorio;

        public ServicioDetalleServicios(IRepositoryDetailService repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<List<DetalleServicioDTO>> ConsultaDetalles(FiltroDetalleServicio filtro)
        {
            var detalles = await _repositorio.GetAll().ToArrayAsync();
            var detalledt = _mapper.Map<List<DetalleServicioDTO>>(detalles);
            return detalledt;
        }

        public async Task<DetalleServicioDTO> ConsultaDetallePorId(Guid id)
        {
            var detallebd = await _repositorio.FindBy(d => d.Id == id).FirstOrDefaultAsync();
            if (detallebd != null)
            {
                return _mapper.Map<DetalleServicioDTO>(detallebd);
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El  detalle  de servicio que solicita no existe en la base de datos" });
            }
        }

        public async Task<DetalleServicioBase> CrearDetalles(DetalleServicioBase detalleb)
        {
            var detalle = _mapper.Map<DetailService>(detalleb);
            await _repositorio.Add(detalle);
            var detalledt = _mapper.Map<DetalleServicioBase>(detalle);
            return detalledt;
        }

        public async Task<DetalleServicioBase> ActualizarDetalle(Guid id, DetalleServicioBase detalle)
        {
            var detallesbd = await _repositorio.FindBy(d => d.Id == id).FirstOrDefaultAsync();
            if (detallesbd != null)
            {
                detallesbd.IdService = detalle.IdServicios;
                detallesbd.Description = detalle.Descripcion;
                detallesbd.IdTypeExtinguisher = detalle.IdTipoExtintor;
                detallesbd.IdWeightExtinguisher = detalle.IdPesoExtintor;
                detallesbd.Price = detalle.Valor;
                detallesbd.Quantity = detalle.Cantidad;
                detallesbd.Total = detalle.Total;

                await _repositorio.Update(detallesbd);
                var detalleAct = _mapper.Map<DetalleServicioBase>(detallesbd);
                return detalleAct;
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El detalle de servicio que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<DetalleServicioDTO> EliminarDetalle(Guid id)
        {
            var detallebd = await _repositorio.FindBy(d => d.Id == id).FirstOrDefaultAsync();
            if (detallebd != null)
            {
                try
                {
                    await _repositorio.Delete(detallebd);
                    var detalleEli = _mapper.Map<DetalleServicioDTO>(detallebd);
                    return detalleEli;
                }
                catch (Exception)
                {

                    throw new HandlingExceptions(HttpStatusCode.InternalServerError, new { Mensaje = "El detalle de  servicio tiene relaciones con otros datos no se puede borrar" });
                }
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El detalle de servicio no existe en la base de datos" });
            }
        }
    }
}
