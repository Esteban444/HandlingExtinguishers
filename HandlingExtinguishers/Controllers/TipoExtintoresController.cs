using FluentValidation;
using HandlingExtinguishers.Dto;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Extinguishers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TipoExtintoresController : ControllerBase
    {
        private readonly IServicioTipoExtintor _servicioTExtintor;
        private readonly IValidator<TipoExtintorBase> _validator;

        public TipoExtintoresController(IServicioTipoExtintor servicioTipo, IValidator<TipoExtintorBase> validator)
        {
            _servicioTExtintor = servicioTipo;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Consultas()
        {
            var tipos = await _servicioTExtintor.ConsultaTipoExtintor();
            var response = new OperationResult<IEnumerable<TipoExtintorDTO>>(tipos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaTipoExtPorId(Guid id)
        {
            var tipo = await _servicioTExtintor.ConsultaTipoId(id);
            var response = new OperationResult<TipoExtintorDTO>(tipo);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearTipoExtintor(TipoExtintorBase tipobase)
        {
            var Validacion = _validator.Validate(tipobase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaTipoExtintor { Errors = errors });
            }
            else
            {
                await _servicioTExtintor.CrearTipoExtintor(tipobase);
                var response = new OperationResult<TipoExtintorBase>(tipobase);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTipo(Guid id, TipoExtintorBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaTipoExtintor { Errors = errors });
            }
            else
            {
                var result = await _servicioTExtintor.ActualizarTipoExtintor(id, actualizar);
                var response = new OperationResult<TipoExtintorBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTipoExt(Guid id)
        {
            var result = await _servicioTExtintor.EliminarTipoExtintor(id);
            var response = new OperationResult<TipoExtintorDTO>(result);
            return Ok(response);

        }
    }
}
