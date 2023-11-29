using FluentValidation;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Extinguishers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PesoExtintoresController : ControllerBase
    {
        private readonly IServicioPesoExtintor _servicioPesoExtintor;
        private readonly IValidator<PesoExtintorBase> _validator;

        public PesoExtintoresController(IServicioPesoExtintor servicioPeso, IValidator<PesoExtintorBase> validator)
        {
            _servicioPesoExtintor = servicioPeso;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Consultas()
        {
            var response = await _servicioPesoExtintor.ConsultaPesoExtintor();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Consulta(Guid id)
        {
            var response = await _servicioPesoExtintor.ConsultaPorId(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(PesoExtintorBase pesobase)
        {
            var Validacion = _validator.Validate(pesobase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaPesoExtintor { Errors = errors });
            }
            else
            {
                var response = await _servicioPesoExtintor.CrearPesoExtintor(pesobase);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPeso(Guid id, PesoExtintorBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaPesoExtintor { Errors = errors });
            }
            else
            {
                var response = await _servicioPesoExtintor.ActualizarPesoExtintor(id, actualizar);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var response = await _servicioPesoExtintor.EliminarPesoExtintor(id);
            return Ok(response);

        }
    }
}
