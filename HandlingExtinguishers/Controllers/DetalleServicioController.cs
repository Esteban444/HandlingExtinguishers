using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Dto;
using HandlingFireExtinguisher.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Services;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DetalleServicioController : ControllerBase
    {
        private readonly IDetailService _servicioDetalle;

        public DetalleServicioController(IDetailService serviciodetalle)
        {
            _servicioDetalle = serviciodetalle;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaDetalles([FromQuery] FiltroDetalleServicio filtro)
        {
            var detalles = await _servicioDetalle.ConsultaDetalles(filtro);
            var response = new OperationResult<IEnumerable<DetalleServicioDTO>>(detalles);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaPorId(Guid id)
        {
            var detalle = await _servicioDetalle.ConsultaDetallePorId(id);
            var response = new OperationResult<DetalleServicioDTO>(detalle);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearDetalle(DetalleServicioBase creardetalle)
        {
            var detallecreado = await _servicioDetalle.CrearDetalles(creardetalle);
            var response = new OperationResult<DetalleServicioBase>(detallecreado);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDetalles(Guid id, DetalleServicioBase actualizar)
        {
            var result = await _servicioDetalle.ActualizarDetalle(id, actualizar);
            var response = new OperationResult<DetalleServicioBase>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var result = await _servicioDetalle.EliminarDetalle(id);
            var response = new OperationResult<DetalleServicioDTO>(result);
            return Ok(response);

        }

    }
}
