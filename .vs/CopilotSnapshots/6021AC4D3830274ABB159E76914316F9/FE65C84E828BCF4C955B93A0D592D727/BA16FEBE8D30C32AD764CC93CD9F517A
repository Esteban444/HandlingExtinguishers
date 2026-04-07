using AutoMapper;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Models.Models;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Extinguishers;
using System.Data.Entity;
using System.Net;

namespace ManagementFireEstinguisher.Core.Servicios
{
    public class ServicioPesoExtintor : IServicioPesoExtintor
    {
        private readonly IBaseRepository<WeightExtinguisher> _repositorio;
        private readonly IMapper _mapper;
        public ServicioPesoExtintor(IBaseRepository<WeightExtinguisher> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PesoExtintorDTO>> ConsultaPesoExtintor()
        {
            var peso = await _repositorio.GetAll().ToListAsync();
            var pesodt = _mapper.Map<IEnumerable<PesoExtintorDTO>>(peso);
            return pesodt;
        }

        public async Task<PesoExtintorDTO> ConsultaPorId(Guid id)
        {
            var pesobd = await _repositorio.FindBy(p => p.Id == id).FirstOrDefaultAsync();
            if (pesobd != null)
            {
                return _mapper.Map<PesoExtintorDTO>(pesobd); ;
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El peso de extintor que solicita no existe en la base de datos" });
            }
        }

        public async Task<PesoExtintorBase> CrearPesoExtintor(PesoExtintorBase pesobase)
        {
            var peso = _mapper.Map<WeightExtinguisher>(pesobase);
            await _repositorio.Add(peso);
            pesobase = _mapper.Map<PesoExtintorBase>(peso);
            return pesobase;
        }

        public async Task<PesoExtintorBase> ActualizarPesoExtintor(Guid id, PesoExtintorBase pesoba)
        {
            var pesobd = await _repositorio.FindBy(p => p.Id == id).FirstOrDefaultAsync();
            if (pesobd != null)
            {
                //pesobd.IdDetalleServ = pesoba.IdDetalleServ;
                pesobd.WeightPound = pesoba.PesoXlibras;

                await _repositorio.Update(pesobd);
                var pesoA = _mapper.Map<PesoExtintorBase>(pesobd);
                return pesoA;
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El peso de extintor que desea actualizar no existe en la base de datos" });
            }
        }


        public async Task<PesoExtintorDTO> EliminarPesoExtintor(Guid id)
        {
            var pesobd = await _repositorio.FindBy(p => p.Id == id).FirstOrDefaultAsync();
            if (pesobd != null)
            {
                try
                {
                    await _repositorio.Delete(pesobd);
                    var pesoE = _mapper.Map<PesoExtintorDTO>(pesobd);
                    return pesoE;
                }
                catch (Exception)
                {
                    throw new HandlingExceptions(HttpStatusCode.InternalServerError, new { Mensaje = "El peso de extintor tiene relacion con productos o detalle de servicio no se puede borrar" });
                }
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El peso de extintor no existe en la base de datos" });
            }
        }

    }
}
