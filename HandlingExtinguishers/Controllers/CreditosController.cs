using FluentValidation;
using HandlingExtinguishers.Dto;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
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
            var creditos = await _serviciCreditos.ConsultaCreditos(filtro);
            var respuesta = new OperationResult<List<CreditoServiciosDTO>>(creditos);
            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaporId(Guid id)
        {
            var credito = await _serviciCreditos.ConsultaCreditoPorId(id);
            var respuesta = new OperationResult<CreditoServiciosDTO>(credito);
            return Ok(respuesta);
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
                var creditoC = await _serviciCreditos.CrearCredito(crearcredito);
                var respueta = new OperationResult<CreditoServicioBase>(creditoC);
                return Ok(respueta);
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
                var creditoAc = await _serviciCreditos.ActualizarCredito(id, actualizar);
                var creditoAdt = new OperationResult<CreditoServicioBase>(creditoAc);
                return Ok(creditoAdt);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCredito(Guid id)
        {
            var result = await _serviciCreditos.EliminarCredito(id);
            var response = new OperationResult<CreditoServiciosDTO>(result);
            return Ok(response);
        }
    }
}
