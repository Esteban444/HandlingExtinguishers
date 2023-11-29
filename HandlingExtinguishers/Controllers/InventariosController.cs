using FluentValidation;
using HandlingExtinguishers.Dto;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Inventories;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguisher.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class InventariosController : ControllerBase
    {
        private readonly IServicioInventario _servicioInventario;
        private readonly IValidator<InventarioBase> _validator;

        public InventariosController(IServicioInventario servicioInventario, IValidator<InventarioBase> validator)
        {
            _servicioInventario = servicioInventario;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaInventarios([FromQuery] FiltroInventario filtro)
        {
            var inventarios = await _servicioInventario.ConsultaInventarios(filtro);
            var response = new OperationResult<IEnumerable<InventarioDTO>>(inventarios);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaPorId(Guid id)
        {

            var inventario = await _servicioInventario.ConsultaInventarioPorId(id);
            var response = new OperationResult<InventarioDTO>(inventario);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(InventarioBase inventariob)
        {
            var Validacion = _validator.Validate(inventariob);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaInventario { Errors = errors });
            }
            else
            {
                await _servicioInventario.CrearInventario(inventariob);
                var response = new OperationResult<InventarioBase>(inventariob);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarInventario(Guid id, InventarioBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaInventario { Errors = errors });
            }
            else
            {
                var result = await _servicioInventario.ActualizarInventario(id, actualizar);
                var response = new OperationResult<InventarioBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var result = await _servicioInventario.EliminarInventario(id);
            var response = new OperationResult<InventarioBase>(result);
            return Ok(response);

        }
    }
}
