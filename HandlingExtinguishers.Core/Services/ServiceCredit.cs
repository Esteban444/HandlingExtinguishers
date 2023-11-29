using AutoMapper;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Credit;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Data.Entity;
using System.Net;

namespace ManejoExtintores.Core.Servicios
{
    public class ServiceCredit : IServicieCredit
    {
        private readonly IRepositoryCredit _repositorio;
        private readonly IMapper _mapper;
        public ServiceCredit(IRepositoryCredit repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<List<CreditoServiciosDTO>> ConsultaCreditos(FiltroCreditos filtros)
        {
            var creditos = await _repositorio.GetAll().ToListAsync();
            var creditosdt = _mapper.Map<List<CreditoServiciosDTO>>(creditos);
            return creditosdt;
        }

        public async Task<CreditoServiciosDTO> ConsultaCreditoPorId(Guid id)
        {
            var creditobd = await _repositorio.FindBy(x => x.Id == id).FirstOrDefaultAsync();
            if (creditobd != null)
            {
                return _mapper.Map<CreditoServiciosDTO>(creditobd);
            }
            else
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { mensaje = "El credito no existe en la base de datos." });
            }
        }

        public async Task<CreditoServicioBase> CrearCredito(CreditoServicioBase credito)
        {
            var creditoc = _mapper.Map<CreditService>(credito);
            await _repositorio.Add(creditoc);
            credito = _mapper.Map<CreditoServicioBase>(creditoc);
            return credito;
        }

        public async Task<CreditoServicioBase> ActualizarCredito(Guid id, CreditoServicioBase credito)
        {
            var creditobd = await _repositorio.FindBy(x => x.Id == id).FirstOrDefaultAsync();
            if (creditobd != null)
            {
                creditobd.IdService = credito.IdServicio;
                creditobd.Advances = credito.Abono;
                creditobd.Debt = credito.Deuda;
                creditobd.Date = credito.Fecha;

                await _repositorio.Update(creditobd);
                var creditoAct = _mapper.Map<CreditoServicioBase>(creditobd);
                return creditoAct;
            }
            else
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { mensaje = "El credito que desea actualizar no existe en la base de datos." });
            }
        }

        public async Task<CreditoServiciosDTO> EliminarCredito(Guid id)
        {
            var creditobd = await _repositorio.FindBy(e => e.Id == id).FirstOrDefaultAsync();
            if (creditobd != null)
            {
                try
                {
                    await _repositorio.Delete(creditobd);
                    var creditoE = _mapper.Map<CreditoServiciosDTO>(creditobd);
                    return creditoE;
                }
                catch (Exception)
                {
                    throw new HandlingExcepciones(HttpStatusCode.NotFound, new { mensaje = "La credito tiene relacion con servicios no se puede borrar." });
                }
            }
            else
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { mensaje = "La credito no existe en la base de datos." });
            }

        }
    }
}
