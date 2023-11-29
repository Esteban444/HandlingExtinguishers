using FluentValidation;
using HandlingExtinguishers.Dto;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Expenses;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class GastosController : ControllerBase
    {

        private readonly IServicioGasto _servicioGasto;
        private readonly IValidator<GastosBase> _validator;

        public GastosController(IServicioGasto servicioGasto, IValidator<GastosBase> validator)
        {
            _servicioGasto = servicioGasto;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaGastos([FromQuery] FiltrosGastos filtros)
        {
            var gastos = await _servicioGasto.GetGastos(filtros);
            var response = new OperationResult<IEnumerable<GastosDTO>>(gastos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaGastoPorId(Guid id)
        {
            var gasto = await _servicioGasto.GetGasto(id);
            var response = new OperationResult<GastosDTO>(gasto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearGasto(GastosBase gastosbase)
        {
            var Validacion = _validator.Validate(gastosbase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaGasto { Errors = errors });
            }
            else
            {
                await _servicioGasto.CrearGasto(gastosbase);
                var response = new OperationResult<GastosBase>(gastosbase);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarGasto(Guid id, GastosBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaGasto { Errors = errors });
            }
            else
            {
                var result = await _servicioGasto.ActualizarGasto(id, actualizar);
                var response = new OperationResult<GastosBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var result = await _servicioGasto.EliminarGasto(id);
            var response = new OperationResult<GastosDTO>(result);
            return Ok(response);

        }
    }
}
