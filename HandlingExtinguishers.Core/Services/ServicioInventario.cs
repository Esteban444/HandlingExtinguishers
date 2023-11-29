using AutoMapper;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Inventories;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Data.Entity;
using System.Net;

namespace ManagementFireEstinguisher.Core.Servicios
{
    public class ServicioInventario : IServicioInventario
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryInventory _repositorio;

        public ServicioInventario(IRepositoryInventory repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventarioDTO>> ConsultaInventarios(FiltroInventario filtro)
        {
            var inventarios = await _repositorio.GetAll().ToListAsync();
            var inventariosdt = _mapper.Map<IEnumerable<InventarioDTO>>(inventarios);
            return inventariosdt;
        }

        public async Task<InventarioDTO> ConsultaInventarioPorId(Guid id)
        {
            var inventario = await _repositorio.FindBy(i => i.Id == id).FirstOrDefaultAsync();
            if (inventario != null)
            {
                return _mapper.Map<InventarioDTO>(inventario);
            }
            else
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El inventario que solicita no existe en la base de datos" });
            }
        }

        public async Task<InventarioBase> CrearInventario(InventarioBase inventario)
        {
            var invent = _mapper.Map<Inventory>(inventario);
            await _repositorio.Add(invent);
            var inventariob = _mapper.Map<InventarioBase>(invent);
            return inventariob;
        }

        public async Task<InventarioBase> ActualizarInventario(Guid id, InventarioBase inventario)
        {
            var inventarios = await _repositorio.FindBy(i => i.Id == id).FirstOrDefaultAsync();
            if (inventarios != null)
            {
                inventarios.IdProduct = inventario.IdProductos;
                inventarios.Date = inventario.Fecha;
                inventarios.Description = inventario.Descripcion;
                inventarios.IdTypeExtinguisher = inventario.IdTipoExtintor;
                inventarios.IdWeigthExtinguisher = inventario.IdPesoExtintor;
                inventarios.Quantity = inventario.Cantidad;
                inventarios.ExpirationDate = inventario.FechaVencimiento;

                await _repositorio.Update(inventarios);
                var inventariAct = _mapper.Map<InventarioBase>(inventarios);
                return inventariAct;
            }
            else
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El inventario que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<InventarioBase> EliminarInventario(Guid id)
        {
            var inventariobd = await _repositorio.FindBy(i => i.Id == id).FirstOrDefaultAsync();
            if (inventariobd != null)
            {
                try
                {
                    await _repositorio.Delete(inventariobd);
                    var inventarioE = _mapper.Map<InventarioBase>(inventariobd);
                    return inventarioE;
                }
                catch (Exception)
                {
                    throw new HandlingExcepciones(HttpStatusCode.InternalServerError, new { Mensaje = "El inventario tiene relacion con productos no se puede borrar" });
                }
            }
            else
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El inventario no existe en la base de datos" });
            }
        }

    }
}
