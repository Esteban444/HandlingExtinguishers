using AutoMapper;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Extinguishers;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ManagementFireEstinguisher.Core.Servicios
{
    public class ServicioTipoExtintor : IServicioTipoExtintor
    {
        private readonly IBaseRepository<TypeExtinguisher> _repositorio;
        private readonly IMapper _mapper;
        public ServicioTipoExtintor(IBaseRepository<TypeExtinguisher> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoExtintorDTO>> ConsultaTipoExtintor()
        {
            var tipos = await _repositorio.GetAll().ToListAsync();
            var tiposdt = _mapper.Map<IEnumerable<TipoExtintorDTO>>(tipos);
            return tiposdt;
        }

        public async Task<TipoExtintorDTO> ConsultaTipoId(Guid id)
        {
            var tipobd = await _repositorio.FindBy(t => t.Id == id).FirstOrDefaultAsync();
            if (tipobd != null)
            {
                return _mapper.Map<TipoExtintorDTO>(tipobd);
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { mensaje = "El tipo de extintor que solicita no existe en la base de datos" });
            }
        }

        public async Task<TipoExtintorBase> CrearTipoExtintor(TipoExtintorBase tipob)
        {
            var tipo = _mapper.Map<TypeExtinguisher>(tipob);
            await _repositorio.Add(tipo);
            var tipoba = _mapper.Map<TipoExtintorBase>(tipo);
            return tipoba;
        }

        public async Task<TipoExtintorBase> ActualizarTipoExtintor(Guid id, TipoExtintorBase tipo)
        {
            var tipobd = await _repositorio.FindBy(t => t.Id == id).FirstOrDefaultAsync();
            if (tipobd != null)
            {
                //tipobd.IdDetalleServ = tipo.IdDetalleServ;
                tipobd.TYpeExtinguisher = tipo.Tipo_Extintor;

                await _repositorio.Update(tipobd);
                var tipoAct = _mapper.Map<TipoExtintorBase>(tipobd);
                return tipoAct;
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NoContent, new { mensaje = "El tipo de extintor que desea actualizar no existe en la base de datos" });
            }
        }


        public async Task<TipoExtintorDTO> EliminarTipoExtintor(Guid id)
        {
            var tipobd = await _repositorio.FindBy(t => t.Id == id).FirstOrDefaultAsync();
            if (tipobd != null)
            {
                try
                {
                    await _repositorio.Delete(tipobd);
                    var tipoEli = _mapper.Map<TipoExtintorDTO>(tipobd);
                    return tipoEli;
                }
                catch (Exception)
                {
                    throw new HandlingExceptions(HttpStatusCode.InternalServerError, new { mensaje = "El tipo de extintor tiene relacion con productos o detalle de servicio no se puede borrar" });
                }
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { mensaje = "El tipo de extintor no existe en la base de datos" });
            }
        }

    }
}
