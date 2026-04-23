using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models.Extinguishers;
using ManagementFireEstinguisher.Dto.Extinguishers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TypeExtinguisherController : ControllerBase
    {
        private readonly ITypeExtinguisherService _servicioTExtintor;
        private readonly IValidator<TypeExtinguisherRequest> _validator;

        public TypeExtinguisherController( ITypeExtinguisherService servicioTipo, IValidator<TypeExtinguisherRequest> validator )
        {
            _servicioTExtintor = servicioTipo;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Consultas()
        {
            var response = await _servicioTExtintor.ConsultaTipoExtintor();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaTipoExtPorId(Guid id)
        {
            var response = await _servicioTExtintor.ConsultaTipoId(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearTipoExtintor( TypeExtinguisherRequest tipobase)
        {
            var Validacion = _validator.Validate(tipobase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaTipoExtintor { Errors = errors });
            }
            else
            {
                var response = await _servicioTExtintor.CrearTipoExtintor(tipobase);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTipo(Guid id, TypeExtinguisherRequest actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaTipoExtintor { Errors = errors });
            }
            else
            {
                var response = await _servicioTExtintor.ActualizarTipoExtintor(id, actualizar);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTipoExt(Guid id)
        {
            var response = await _servicioTExtintor.EliminarTipoExtintor(id);
            return Ok(response);

        }
    }
}
