using FluentValidation;
using HandlingExtinguisher.Contracts.Interfaces.Services;
using HandlingExtinguisher.Dto.Clients;
using HandlingExtinguishers.Dto;
using ManagementFireEstinguisher.Dto.Credit;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DetalleExtintorClientesController : ControllerBase
    {
        private readonly IServicioDetalleExtClientes _servicioDetalleExtClientes;
        private readonly IValidator<BaseDetailExtinguisherClient> _validator;
        public DetalleExtintorClientesController(IServicioDetalleExtClientes servicioDetalleExtClientes,
            IValidator<BaseDetailExtinguisherClient> validator)
        {
            _servicioDetalleExtClientes = servicioDetalleExtClientes;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaDetalleExtClientes([FromQuery] FiltroDetalleExtClientes filtro)
        {
            var detalleextintorclientes = await _servicioDetalleExtClientes.ConsultaDetalleClientes(filtro);
            var resultado = new OperationResult<List<DetailExtinguisherClientDto>>(detalleextintorclientes);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaDetalleExtclientePorId(Guid id)
        {
            var detalleExtintorCliente = await _servicioDetalleExtClientes.ConsultaDetalleExtClientePorId(id);
            var resultado = new OperationResult<DetailExtinguisherClientDto>(detalleExtintorCliente);
            return Ok(resultado);
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
                var creardetalleExtintorcliente = await _servicioDetalleExtClientes.CrearDetalleExtCliente(crear);
                var resultado = new OperationResult<BaseDetailExtinguisherClient>(creardetalleExtintorcliente);
                return Ok(resultado);
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
                var actualizardetalleextintorcliente = await _servicioDetalleExtClientes.ActualizarDetalleExtCliente(id, actualizar);
                var detalleextCliAct = new OperationResult<BaseDetailExtinguisherClient>(actualizardetalleextintorcliente);
                return Ok(detalleextCliAct);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCredito(Guid id)
        {
            var resultado = await _servicioDetalleExtClientes.EliminarDetalleExtCliente(id);
            var respuesta = new OperationResult<DetailExtinguisherClientDto>(resultado);
            return Ok(respuesta);
        }

    }
}
