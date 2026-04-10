using FluentValidation;
using HandlingExtinguisher.Dto.Clients;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Credit;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DetailExtinguisherClientController : ControllerBase
    {
        private readonly IServiceDetailExtClients _servicioDetalleExtClientes;
        private readonly IValidator<BaseDetailExtinguisherClient> _validator;
        public DetailExtinguisherClientController(IServiceDetailExtClients servicioDetalleExtClientes,
            IValidator<BaseDetailExtinguisherClient> validator)
        {
            _servicioDetalleExtClientes = servicioDetalleExtClientes;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaDetalleExtClientes([FromQuery] FiltroDetalleExtClientes filtro)
        {
            var response = await _servicioDetalleExtClientes.ConsultaDetalleClientes(filtro);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaDetalleExtclientePorId(Guid id)
        {
            var response = await _servicioDetalleExtClientes.ConsultaDetalleExtClientePorId(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearDetalleExtintorCliente([FromBody] BaseDetailExtinguisherClient crear)
        {
            var Validacion = _validator.Validate(crear);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new ResponseDetailExtinguisherClient { Errors = errors });
            }
            else
            {
                var response = await _servicioDetalleExtClientes.CrearDetalleExtCliente(crear);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCredito(Guid id, BaseDetailExtinguisherClient actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaCredito { Errors = errors });
            }
            else
            {
                var response = await _servicioDetalleExtClientes.ActualizarDetalleExtCliente(id, actualizar);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCredito(Guid id)
        {
            var response = await _servicioDetalleExtClientes.EliminarDetalleExtCliente(id);
            return Ok(response);
        }

    }
}
