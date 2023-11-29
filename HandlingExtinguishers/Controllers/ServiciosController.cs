using FluentValidation;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto;
using ManagementFireEstinguisher.Dto.Services;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IServiceOfService _serviciodeServicio;
        private readonly IValidator<ServicioBase> _validator;

        public ServiciosController(IServiceOfService serviciodeservicio, IValidator<ServicioBase> validator)
        {
            _serviciodeServicio = serviciodeservicio;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaServicios([FromQuery] FiltroServicios filtros)
        {
            var response = await _serviciodeServicio.ConsultarServicios(filtros);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaPorId(Guid id)
        {
            var response = await _serviciodeServicio.ConsultaServicio(id);
            return Ok(response);
        }

        [HttpPost("Crear-Servicio-Detalle")]
        public async Task<IActionResult> CreacionDetalleServicio(ServicioBase serviciobase)
        {
            var Validacion = _validator.Validate(serviciobase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaServicios { Errors = errors });
            }
            else
            {
                var response = await _serviciodeServicio.CrearServicioDetalle(serviciobase);
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ServicioBase serviciob)
        {
            var Validacion = _validator.Validate(serviciob);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaServicios { Errors = errors });
            }
            else
            {
                var response = await _serviciodeServicio.CrearServicios(serviciob);
                return Ok(response);
            }
        }

        [HttpPut("modificar-estado")]
        public async Task<IActionResult> ModificarEstado(Guid id, ModificarEstado modificar)
        {
            var response = await _serviciodeServicio.ActualizarEstado(id, modificar);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarServicios(Guid id, ServicioBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaServicios { Errors = errors });
            }
            else
            {
                var response = await _serviciodeServicio.ActualizarServicios(id, actualizar);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var response = await _serviciodeServicio.EliminarServicios(id);
            return Ok(response);
        }
    }
}
