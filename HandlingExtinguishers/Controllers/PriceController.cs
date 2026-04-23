using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Prices;
using ManagementFireEstinguisher.Dto.Prices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService _servicioPrecios;
        private readonly IValidator<PrecioBase> _validator;

        public PriceController(IPriceService servicioPrecio, IValidator<PrecioBase> validator)
        {
            _servicioPrecios = servicioPrecio;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultasPrecios([FromQuery] FilterPrices filtro)
        {
            var response = await _servicioPrecios.ConsultaPrecios(filtro);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaPrecio(Guid id)
        {
            var response = await _servicioPrecios.ConsultaPor(id);
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
                var response = await _servicioPrecios.CrearPrecio(preciobase);
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
                var response = await _servicioPrecios.ActualizarPrecio(id, actualizar);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPrecios(Guid id)
        {
            var response = await _servicioPrecios.EliminarPrecio(id);
            return Ok(response);

        }
    }
}
