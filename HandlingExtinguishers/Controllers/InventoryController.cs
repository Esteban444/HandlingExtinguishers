using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Inventories;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguisher.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IServiceInventory _servicioInventario;
        private readonly IValidator<InventarioBase> _validator;

        public InventoryController( IServiceInventory servicioInventario, IValidator<InventarioBase> validator )
        {
            _servicioInventario = servicioInventario;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaInventarios([FromQuery] FiltroInventario filtro)
        {
            var response = await _servicioInventario.ConsultaInventarios(filtro);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaPorId(Guid id)
        {

            var response = await _servicioInventario.ConsultaInventarioPorId(id);
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
                var response = await _servicioInventario.CrearInventario(inventariob);
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
                var response = await _servicioInventario.ActualizarInventario(id, actualizar);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var response = await _servicioInventario.EliminarInventario(id);
            return Ok(response);

        }
    }
}
