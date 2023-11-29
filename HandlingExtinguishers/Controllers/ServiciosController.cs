using FluentValidation;
using HandlingExtinguishers.Dto;
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
            var servicios = await _serviciodeServicio.ConsultarServicios(filtros);
            var response = new OperationResult<IEnumerable<ServicioDTO>>(servicios);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaPorId(Guid id)
        {
            var servicio = await _serviciodeServicio.ConsultaServicio(id);
            var response = new OperationResult<ServicioDTO>(servicio);
            return Ok(response);
        }

        [HttpPost("Crear-Servicio-Detalle")]
        public IActionResult CreacionDetalleServicio(ServicioBase serviciobase)
        {
            var Validacion = _validator.Validate(serviciobase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaServicios { Errors = errors });
            }
            else
            {
                _serviciodeServicio.CrearServicioDetalle(serviciobase);
                var respuesta = new OperationResult<ServicioBase>(serviciobase);
                return Ok(respuesta);
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
                await _serviciodeServicio.CrearServicios(serviciob);
                var response = new OperationResult<ServicioBase>(serviciob);
                return Ok(response);
            }
        }

        [HttpPut("modificar-estado")]
        public async Task<IActionResult> ModificarEstado(Guid id, ModificarEstado modificar)
        {
            var resultado = await _serviciodeServicio.ActualizarEstado(id, modificar);
            var respuesta = new OperationResult<ModificarEstado>(resultado);
            return Ok(respuesta);
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
                var resultado = await _serviciodeServicio.ActualizarServicios(id, actualizar);
                var respuesta = new OperationResult<ServicioBase>(resultado);
                return Ok(respuesta);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var resultado = await _serviciodeServicio.EliminarServicios(id);
            var respuesta = new OperationResult<ServicioDTO>(resultado);
            return Ok(respuesta);
        }
    }
}
