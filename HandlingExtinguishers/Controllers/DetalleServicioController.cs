using HandlingExtinguishers.Contracts.Interfaces.Services;
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
            var response = await _servicioDetalle.ConsultaDetalles(filtro);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultaPorId(Guid id)
        {
            var response = await _servicioDetalle.ConsultaDetallePorId(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearDetalle(DetalleServicioBase creardetalle)
        {
            var response = await _servicioDetalle.CrearDetalles(creardetalle);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDetalles(Guid id, DetalleServicioBase actualizar)
        {
            var response = await _servicioDetalle.ActualizarDetalle(id, actualizar);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var response = await _servicioDetalle.EliminarDetalle(id);
            return Ok(response);

        }

    }
}
