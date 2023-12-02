using AutoMapper;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Models.Models;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Expenses;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Data.Entity;
using System.Net;

namespace ManejoExtintores.Core.Servicios
{
    public class ServicioGasto : IServicioGasto
    {
        private readonly IRepositoryExpense _repositorio;
        private readonly IMapper _mapper;

        public ServicioGasto(IRepositoryExpense repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GastosDTO>> GetGastos(FiltrosGastos filtros)
        {
            var gastos = await _repositorio.GetAll().ToListAsync();
            var gastosdt = _mapper.Map<IEnumerable<GastosDTO>>(gastos);
            return gastosdt;
        }

        public async Task<GastosDTO> GetGasto(Guid id)
        {
            var gastobd = await _repositorio.FindBy(c => c.Id == id).FirstOrDefaultAsync();
            if (gastobd != null)
            {
                return _mapper.Map<GastosDTO>(gastobd);
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El registro de gasto no existe en la base de datos" });
            }
        }

        public async Task<GastosBase> CrearGasto(GastosBase gastobs)
        {
            var gasto = _mapper.Map<Expense>(gastobs);
            await _repositorio.Add(gasto);
            gastobs = _mapper.Map<GastosBase>(gasto);
            return gastobs;
        }

        public async Task<GastosBase> ActualizarGasto(Guid id, GastosBase gastoac)
        {
            var gastobd = await _repositorio.FindBy(c => c.Id == id).FirstOrDefaultAsync();
            if (gastobd != null)
            {
                gastobd.Description = gastoac.Descripcion;
                gastobd.Date = gastoac.Fecha;
                gastobd.Quantity = gastoac.Cantidad;
                gastobd.Total = gastoac.Total;

                await _repositorio.Update(gastobd);
                var gastoA = _mapper.Map<GastosBase>(gastobd);
                return gastoA;
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El registro de gasto que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<GastosDTO> EliminarGasto(Guid id)
        {
            var gastobd = await _repositorio.FindBy(c => c.Id == id).FirstOrDefaultAsync();
            if (gastobd != null)
            {
                await _repositorio.Delete(gastobd);
                var gastoE = _mapper.Map<GastosDTO>(gastobd);
                return gastoE;
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El gasto no existe en la base de datos" });
            }
        }
    }
}
