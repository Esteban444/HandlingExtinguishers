using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Models;
using ManagementFireEstinguisher.Dto.Products;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ManejoExtintores.Core.Servicios
{
    public class ServicioProducto : IServiceProducts
    {
        private readonly IRepositoryProduct _repositorio;
        private readonly IMapper _mapper;
        public ServicioProducto(IRepositoryProduct repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductoDTO>> ConsultaProductos(FiltroProductos filtros)
        {
            var productos = await _repositorio.GetAll().ToListAsync();
            var productodt = _mapper.Map<IEnumerable<ProductoDTO>>(productos);
            return productodt;
        }

        public async Task<ProductoDTO> ConsultaPorId(Guid id)
        {
            var productobd = await _repositorio.FindBy(p => p.Id == id).FirstOrDefaultAsync();
            if (productobd != null)
            {
                return _mapper.Map<ProductoDTO>(productobd);
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.ProductNotFound );
            }
        }

        public async Task<ProductoBase> CrearProducto(ProductoBase productobase)
        {
            var producto = _mapper.Map<Product>(productobase);
            await _repositorio.Add(producto);
            productobase = _mapper.Map<ProductoBase>(producto);
            return productobase;
        }

        public async Task<ProductoBase> ActualizarProducto(Guid id, ProductoBase productobs)
        {
            var productosbd = await _repositorio.FindBy(p => p.Id == id).FirstOrDefaultAsync();
            if (productosbd != null)
            {
                productosbd.IdTypeExtinguisher = productobs.IdTipoExtintor;
                productosbd.IdWeightExtinguisher = productobs.IdPesoExtintor;
                productosbd.TypeProduct = productobs.TipoProducto;

                await _repositorio.Update(productosbd);
                productobs = _mapper.Map<ProductoBase>(productosbd);
                return productobs;
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.ProductNotFound );
            }
        }

        public async Task<ProductoBase> EliminarProducto(Guid id)
        {
            var productobd = await _repositorio.FindBy(p => p.Id == id).FirstOrDefaultAsync();
            if (productobd != null)
            {
                try
                {
                    await _repositorio.Delete(productobd);
                    var productoE = _mapper.Map<ProductoBase>(productobd);
                    return productoE;
                }
                catch (Exception)
                {

                    throw new HandlingExceptions( HandlingExtinguisherResources.RelatedProduct );
                }
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.ProductNotFound );
            }
        }
    }
}
