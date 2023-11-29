using AutoMapper;
using HandlingExtinguisher.Contracts.Interfaces.Services;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguisher.Dto.Clients;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Net;

namespace ManejoExtintores.Core.Servicios
{
    public class ServicioDetalleExtClientes : IServicioDetalleExtClientes
    {
        private readonly IRepositoryDetailExtinguisherClient _repositorioDetalleExtClientes;
        private readonly IMapper _mapper;
        public ServicioDetalleExtClientes(IRepositoryDetailExtinguisherClient repositorio, IMapper mapper)
        {
            _repositorioDetalleExtClientes = repositorio;
            _mapper = mapper;
        }

        public async Task<List<DetailExtinguisherClientDto>> ConsultaDetalleClientes(FiltroDetalleExtClientes filtro)
        {
            var detalleextClientes = await _repositorioDetalleExtClientes.GetAll().ToListAsync();
            var detalleextclientesdt = _mapper.Map<List<DetailExtinguisherClientDto>>(detalleextClientes);
            return detalleextclientesdt;
        }

        public async Task<DetailExtinguisherClientDto> ConsultaDetalleExtClientePorId(Guid id)
        {
            var detalleextintorCliente = await _repositorioDetalleExtClientes.FindBy(x => x.Id == id).FirstOrDefaultAsync();
            if (detalleextintorCliente != null)
            {
                return _mapper.Map<DetailExtinguisherClientDto>(detalleextintorCliente);
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { mensaje = "El detalle de extintor de cliente no existe en la base de datos." });
            }
        }

        public async Task<BaseDetailExtinguisherClient> CrearDetalleExtCliente(BaseDetailExtinguisherClient detalleExtCliente)
        {
            var detalleextintorcliente = _mapper.Map<DetailExtinguisherClient>(detalleExtCliente);
            await _repositorioDetalleExtClientes.Add(detalleextintorcliente); ;
            detalleExtCliente = _mapper.Map<BaseDetailExtinguisherClient>(detalleextintorcliente);
            return detalleExtCliente;
        }

        public async Task<BaseDetailExtinguisherClient> ActualizarDetalleExtCliente(Guid id, BaseDetailExtinguisherClient detalleExtCliente)
        {
            var detalleactualizarbd = await _repositorioDetalleExtClientes.FindBy(x => x.Id == id).FirstOrDefaultAsync();
            if (detalleactualizarbd != null)
            {
                detalleactualizarbd.IdClients = detalleExtCliente.IdClients;
                detalleactualizarbd.TypeExtinguisher = detalleExtCliente.TypeExtinguisher ?? detalleactualizarbd.TypeExtinguisher;
                detalleactualizarbd.WeightExtinguisher = detalleExtCliente.TypeExtinguisher ?? detalleactualizarbd.TypeExtinguisher;
                detalleactualizarbd.Quantity = detalleExtCliente.Quantity ?? detalleactualizarbd.Quantity;
                detalleactualizarbd.MaintenanceDate = detalleExtCliente.MaintenanceDate ?? detalleactualizarbd.MaintenanceDate;
                detalleactualizarbd.ExpirationDate = detalleExtCliente.ExpirationDate ?? detalleactualizarbd.ExpirationDate;

                await _repositorioDetalleExtClientes.Update(detalleactualizarbd);
                var detalleExtclienteactualizado = _mapper.Map<BaseDetailExtinguisherClient>(detalleactualizarbd);
                return detalleExtclienteactualizado;
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { mensaje = "El detalle extintor del cliente que desea actualizar no existe en la base de datos." });
            }
        }

        public async Task<DetailExtinguisherClientDto> EliminarDetalleExtCliente(Guid id)
        {
            var detalleExtclientebd = await _repositorioDetalleExtClientes.FindBy(e => e.Id == id).FirstOrDefaultAsync();
            if (detalleExtclientebd != null)
            {
                try
                {
                    await _repositorioDetalleExtClientes.Delete(detalleExtclientebd);
                    var detalleExtClienteE = _mapper.Map<DetailExtinguisherClientDto>(detalleExtclientebd);
                    return detalleExtClienteE;
                }
                catch (Exception)
                {
                    throw new HandlingExceptions(HttpStatusCode.NotFound, new { mensaje = "La detalle extintor de este cliente tiene relaciones con otras tablas no se puede borrar." });
                }
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { mensaje = "La detalle extintor de cliente no existe en la base de datos." });
            }

        }
    }
}
