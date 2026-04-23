using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Inventories;
using HandlingExtinguishers.Models.Models;
using ManagementFireEstinguisher.Dto.Inventories;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HandlingExtinguishers.Core.Services
{
    public class InventaryService : IInventoryService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryInventory _repositorio;

        public InventaryService(IRepositoryInventory repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventarioDTO>> ConsultaInventarios(FilterInventory filtro)
        {
            var inventarios = await _repositorio.GetAll().ToListAsync();
            var inventariosdt = _mapper.Map<IEnumerable<InventarioDTO>>(inventarios);
            return inventariosdt;
        }

        public async Task<InventarioDTO> ConsultaInventarioPorId(Guid id)
        {
            var inventario = await _repositorio.FindBy(i => i.InventoryId == id).FirstOrDefaultAsync();
            if (inventario != null)
            {
                return _mapper.Map<InventarioDTO>(inventario);
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.InventoryNotFound );
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
            var inventarios = await _repositorio.FindBy(i => i.InventoryId == id).FirstOrDefaultAsync();
            if (inventarios != null)
            {
                inventarios.ProductId = inventario.IdProductos;
                inventarios.Date = inventario.Fecha;
                inventarios.Description = inventario.Descripcion;
                inventarios.TypeExtinguisherId = inventario.IdTipoExtintor;
                inventarios.WeightExtinguisherId = inventario.IdPesoExtintor;
                inventarios.Quantity = inventario.Cantidad;
                inventarios.ExpirationDate = inventario.FechaVencimiento;

                await _repositorio.Update(inventarios);
                var inventariAct = _mapper.Map<InventarioBase>(inventarios);
                return inventariAct;
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.InventoryNotFound );
            }
        }

        public async Task<InventarioBase> EliminarInventario(Guid id)
        {
            var inventariobd = await _repositorio.FindBy(i => i.InventoryId == id).FirstOrDefaultAsync();
            if (inventariobd != null)
            {
                try
                {
                    await _repositorio.Delete(inventariobd);
                    var inventarioE = _mapper.Map<InventarioBase>(inventariobd);
                    return inventarioE;
                }
                catch ( Exception )
                {
                    throw new HandlingExceptions( HandlingExtinguisherResources.RelatedInventory );
                }
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.InventoryNotFound );
            }
        }

    }
}
