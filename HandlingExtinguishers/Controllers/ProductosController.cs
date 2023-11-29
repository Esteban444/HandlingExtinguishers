using FluentValidation;
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
            var response = await _servicioProducto.ConsultaProductos(filtros);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaProductoPorId(Guid id)
        {
            var response = await _servicioProducto.ConsultaPorId(id);
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
                var response = await _servicioProducto.CrearProducto(productobase);
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
                var response = await _servicioProducto.ActualizarProducto(id, actualizar);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var response = await _servicioProducto.EliminarProducto(id);
            return Ok(response);

        }
    }
}
