using AutoMapper;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Models.Models;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Prices;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Data.Entity;
using System.Net;

namespace ManejoExtintores.Core.Servicios
{
    public class ServicioPrecios : IServicioPrecios
    {
        private readonly IRepositoryPrice _repositorio;
        private readonly IMapper _mapper;
        public ServicioPrecios(IRepositoryPrice repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PrecioDTO>> ConsultaPrecios(FiltroPrecios filtro)
        {
            var precios = await _repositorio.GetAll().ToListAsync();
            var preciodt = _mapper.Map<IEnumerable<PrecioDTO>>(precios);
            return preciodt;
        }

        public async Task<PrecioDTO> ConsultaPor(Guid id)
        {
            var preciobd = await _repositorio.FindBy(p => p.Id == id).FirstOrDefaultAsync();
            if (preciobd != null)
            {
                return _mapper.Map<PrecioDTO>(preciobd);
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El precio que solicita no existe en la base de datos" });
            }
        }

        public async Task<PrecioBase> CrearPrecio(PrecioBase preciobase)
        {
            var precio = _mapper.Map<Price>(preciobase);
            await _repositorio.Add(precio);
            preciobase = _mapper.Map<PrecioBase>(precio);
            return preciobase;
        }


        public async Task<PrecioBase> ActualizarPrecio(Guid id, PrecioBase precioAct)
        {
            var precios = await _repositorio.FindBy(p => p.Id == id).FirstOrDefaultAsync();
            if (precios != null)
            {
                precios.IdProduct = precioAct.IdProductos;
                precios.Description = precioAct.Descripcion;
                precios.price = precioAct.Valor;
                precios.Iva = precioAct.Iva;

                await _repositorio.Update(precios);
                precioAct = _mapper.Map<PrecioBase>(precios);
                return precioAct;
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El precio que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<PrecioDTO> EliminarPrecio(Guid id)
        {
            var preciobd = await _repositorio.FindBy(p => p.Id == id).FirstOrDefaultAsync();
            if (preciobd != null)
            {
                try
                {
                    await _repositorio.Delete(preciobd);
                    var precioE = _mapper.Map<PrecioDTO>(preciobd);
                    return precioE;
                }
                catch (Exception)
                {
                    throw new HandlingExceptions(HttpStatusCode.InternalServerError, new { Mensaje = "El Precio tiene relacion con productos o detalle de servicio no se puede borrar" });
                }
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El Precio no existe en la base de datos" });
            }
        }
    }
}
