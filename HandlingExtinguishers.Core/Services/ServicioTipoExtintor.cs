using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Models;
using ManagementFireEstinguisher.Dto.Extinguishers;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ManagementFireEstinguisher.Core.Servicios
{
    public class ServicioTipoExtintor : IServiceTypeExtinguisher
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
                throw new HandlingExceptions( HandlingExtinguisherResources.TypeExtinguisherNotFound );
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
                throw new HandlingExceptions( HandlingExtinguisherResources.TypeExtinguisherNotFound );
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
                    throw new HandlingExceptions( HandlingExtinguisherResources.TypeExtinguisherRelated );
                }
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.TypeExtinguisherNotFound );
            }
        }

    }
}
