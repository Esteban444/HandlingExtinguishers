using AutoMapper;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Models.Models;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto;
using ManagementFireEstinguisher.Dto.Services;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Data.Entity;
using System.Net;

namespace ManejoExtintores.Core.Servicios
{
    public class ServiceOfService : IServiceOfService
    {
        private readonly IRepositoryService _repositorio;

        private readonly IMapper _mapper;
        public ServiceOfService(IRepositoryService repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServicioDTO>> ConsultarServicios(FiltroServicios filtros)
        {
            var servicios = await _repositorio.GetAll().ToListAsync();
            var serviciosdt = _mapper.Map<IEnumerable<ServicioDTO>>(servicios);
            return serviciosdt;
        }

        public async Task<ServicioDTO> ConsultaServicio(Guid id)
        {
            var serviciobd = await _repositorio.FindBy(s => s.Id == id).FirstOrDefaultAsync();
            if (serviciobd != null)
            {
                return _mapper.Map<ServicioDTO>(serviciobd);
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El servicio que solicita no existe en la base de datos." });
            }
        }

        public async Task<ServicioBase> CrearServicioDetalle(ServicioBase serviciob)
        {
            // await _repositorio.Add(serviciob);
            serviciob = _mapper.Map<ServicioBase>(serviciob);
            return serviciob;
        }

        public async Task<ServicioBase> CrearServicios(ServicioBase crearserviciob)
        {
            var crearservicios = _mapper.Map<Service>(crearserviciob);
            await _repositorio.Add(crearservicios);
            var serviciob = _mapper.Map<ServicioBase>(crearservicios);
            return serviciob;
        }

        public async Task<ModificarEstado> ActualizarEstado(Guid id, ModificarEstado modificar)
        {
            var serviciobd = await _repositorio.FindBy(s => s.Id == id).FirstOrDefaultAsync();
            if (serviciobd != null)
            {
                serviciobd.StateService = modificar.Estado ?? serviciobd.StateService;

                await _repositorio.Update(serviciobd);
                var servicioAct = _mapper.Map<ModificarEstado>(serviciobd);
                return servicioAct;
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El servicio que desea actualizarle el estado no existe en la base de datos" });
            }
        }

        public async Task<ServicioBase> ActualizarServicios(Guid id, ServicioBase servicio)
        {
            var serviciobd = await _repositorio.FindBy(s => s.Id == id).FirstOrDefaultAsync();
            if (serviciobd != null)
            {
                serviciobd.IdClient = servicio.IdClientes;
                serviciobd.IdEmployee = servicio.IdEmpleados;
                serviciobd.ServiceDate = servicio.FechaServicio ?? serviciobd.ServiceDate;
                serviciobd.Price = servicio.Valor ?? serviciobd.Price;
                serviciobd.StateService = servicio.Estado ?? serviciobd.StateService;

                await _repositorio.Update(serviciobd);
                var servicioAct = _mapper.Map<ServicioBase>(serviciobd);
                return servicioAct;
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El servicio que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<ServicioDTO> EliminarServicios(Guid id)
        {
            var serviciobd = await _repositorio.FindBy(s => s.Id == id).FirstOrDefaultAsync();
            if (serviciobd != null)
            {
                try
                {
                    await _repositorio.Delete(serviciobd);
                    var servicioEliminado = _mapper.Map<ServicioDTO>(serviciobd);
                    return servicioEliminado;
                }
                catch (Exception)
                {
                    throw new HandlingExceptions(HttpStatusCode.InternalServerError, new { Mensaje = "El servicio tiene relaciones con otros datos no se puede borrar." });
                }
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El servicio no existe en la base de datos." });
            }
        }
    }
}
