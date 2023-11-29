using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Credit;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CreditosController : ControllerBase
    {
        private readonly IServicieCredit _serviciCreditos;
        private readonly IValidator<CreditoServicioBase> _validator;

        public CreditosController(IServicieCredit servicioCreditos, IValidator<CreditoServicioBase> validator)
        {
            _serviciCreditos = servicioCreditos;
            _validator = validator;
        }
        [HttpGet]
        public async Task<IActionResult> ConsultaCreditos([FromQuery] FiltroCreditos filtro)
        {
            var response = await _serviciCreditos.ConsultaCreditos(filtro);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaporId(Guid id)
        {
            var response = await _serviciCreditos.ConsultaCreditoPorId(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCredito(CreditoServicioBase crearcredito)
        {
            var Validacion = _validator.Validate(crearcredito);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaCredito { Errors = errors });
            }
            else
            {
                var response = await _serviciCreditos.CrearCredito(crearcredito);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCredito(Guid id, CreditoServicioBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaCredito { Errors = errors });
            }
            else
            {
                var response = await _serviciCreditos.ActualizarCredito(id, actualizar);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCredito(Guid id)
        {
            var response = await _serviciCreditos.EliminarCredito(id);
            return Ok(response);
        }
    }
}
