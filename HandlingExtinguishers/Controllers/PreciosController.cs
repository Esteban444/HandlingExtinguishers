using FluentValidation;
using HandlingExtinguishers.Dto;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Prices;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PreciosController : ControllerBase
    {
        private readonly IServicioPrecios _servicioPrecios;
        private readonly IValidator<PrecioBase> _validator;

        public PreciosController(IServicioPrecios servicioPrecio, IValidator<PrecioBase> validator)
        {
            _servicioPrecios = servicioPrecio;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultasPrecios([FromQuery] FiltroPrecios filtro)
        {
            var precios = await _servicioPrecios.ConsultaPrecios(filtro);
            var response = new OperationResult<IEnumerable<PrecioDTO>>(precios);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaPrecio(Guid id)
        {
            var precio = await _servicioPrecios.ConsultaPor(id);
            var response = new OperationResult<PrecioDTO>(precio);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPrecios(PrecioBase preciobase)
        {
            var Validacion = _validator.Validate(preciobase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaPrecios { Errors = errors });
            }
            else
            {
                await _servicioPrecios.CrearPrecio(preciobase);
                var response = new OperationResult<PrecioBase>(preciobase);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPrecios(Guid id, PrecioBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaPrecios { Errors = errors });
            }
            else
            {
                var result = await _servicioPrecios.ActualizarPrecio(id, actualizar);
                var response = new OperationResult<PrecioBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPrecios(Guid id)
        {
            var result = await _servicioPrecios.EliminarPrecio(id);
            var response = new OperationResult<PrecioDTO>(result);
            return Ok(response);

        }
    }
}
