using FluentValidation;
using HandlingExtinguishers.Dto;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Products;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly IServicioProducto _servicioProducto;
        private readonly IValidator<ProductoBase> _validator;

        public ProductosController(IServicioProducto servicioProducto, IValidator<ProductoBase> validator)
        {
            _servicioProducto = servicioProducto;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaProductos([FromQuery] FiltroProductos filtros)
        {
            var productos = await _servicioProducto.ConsultaProductos(filtros);
            var response = new OperationResult<IEnumerable<ProductoDTO>>(productos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaProductoPorId(Guid id)
        {
            var producto = await _servicioProducto.ConsultaPorId(id);
            var response = new OperationResult<ProductoDTO>(producto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearProductos(ProductoBase productobase)
        {
            var Validacion = _validator.Validate(productobase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaProductos { Errors = errors });
            }
            else
            {
                await _servicioProducto.CrearProducto(productobase);
                var response = new OperationResult<ProductoBase>(productobase);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProductos(Guid id, ProductoBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaProductos { Errors = errors });
            }
            else
            {
                var result = await _servicioProducto.ActualizarProducto(id, actualizar);
                var response = new OperationResult<ProductoBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var result = await _servicioProducto.EliminarProducto(id);
            var response = new OperationResult<ProductoBase>(result);
            return Ok(response);

        }
    }
}
