using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Extinguishers;
using HandlingExtinguishers.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementFireEstinguisher.Core.Servicios
{
    public class TypeExtinguisherService : ITypeExtinguisherService
    {
        private readonly IBaseRepository<TypeExtinguisherRequest> _repositorio;
        private readonly IMapper _mapper;
        public TypeExtinguisherService( IBaseRepository<TypeExtinguisherRequest> repositorio, IMapper mapper )
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TypeExtinguisherRequest>> ConsultaTipoExtintor()
        {
            var tipos = await _repositorio.GetAll().ToListAsync();
            var tiposdt = _mapper.Map<IEnumerable<TypeExtinguisherRequest>>(tipos);
            return tiposdt;
        }

        public async Task<TypeExtinguisherRequest> ConsultaTipoId(Guid id)
        {
            var tipobd = await _repositorio.FindBy(t => t.TypeExtinguisherId == id).FirstOrDefaultAsync();
            if (tipobd != null)
            {
                return _mapper.Map<TypeExtinguisherRequest>(tipobd);
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.TypeExtinguisherNotFound );
            }
        }

        public async Task<TypeExtinguisherRequest> CrearTipoExtintor( TypeExtinguisherRequest request )
        {
            var result = _mapper.Map<TypeExtinguisherRequest>(request);

            await _repositorio.Add(result);

            var response = _mapper.Map<TypeExtinguisherRequest>(result);

            return response;
        }

        public async Task<TypeExtinguisherRequest> ActualizarTipoExtintor(Guid id, TypeExtinguisherRequest tipo)
        {
            var tipobd = await _repositorio.FindBy(t => t.TypeExtinguisherId == id).FirstOrDefaultAsync();
            if (tipobd != null)
            {
                //tipobd.IdDetalleServ = tipo.IdDetalleServ;
                tipobd.TypeExtinguisherId = tipo.TypeExtinguisherId;
                await _repositorio.Update(tipobd);
                var tipoAct = _mapper.Map<TypeExtinguisherRequest>(tipobd);
                return tipoAct;
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.TypeExtinguisherNotFound );
            }
        }


        public async Task<TypeExtinguisherRequest> EliminarTipoExtintor(Guid id)
        {
            var tipobd = await _repositorio.FindBy(t => t.TypeExtinguisherId == id).FirstOrDefaultAsync();
            if (tipobd != null)
            {
                try
                {
                    await _repositorio.Delete(tipobd);
                    var tipoEli = _mapper.Map<TypeExtinguisherRequest>(tipobd);
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
