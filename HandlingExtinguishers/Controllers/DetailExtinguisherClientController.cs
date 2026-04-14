using FluentValidation;
using HandlingExtinguisher.Dto.Clients;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using ManagementFireEstinguisher.Dto.Credit;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.Controllers
{
    [Route("api/detail-extinguisher-client")]
    [ApiController]
    [Authorize]
    public class DetailExtinguisherClientController( IServiceDetailExtinguisherClients serviceDetailExtinguisherClients,
                                                     IValidator<BaseDetailExtinguisherClient> validator ) : ControllerBase
    {
        private readonly IServiceDetailExtinguisherClients serviceDetailExtinguisherClients = serviceDetailExtinguisherClients;
        private readonly IValidator<BaseDetailExtinguisherClient> validator = validator;

        [HttpGet]
        public async Task<IActionResult> SearchDetailClients( [FromQuery] FiltroDetalleExtClientes filter )
        {
            var response = await serviceDetailExtinguisherClients.SearchDetailClients( filter );

            return Ok(response);
        }

        [HttpGet("search-by/{idDetail}")]
        public async Task<IActionResult> SearchDetailClientById( Guid idDetail )
        {
            var response = await serviceDetailExtinguisherClients.SearchDetailClientById( idDetail );

            return Ok( response );
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetailExtinguisher( [FromBody] BaseDetailExtinguisherClient request )
        {
            var Validacion = validator.Validate( request );

            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(error => error.ErrorMessage);

                return BadRequest(new ResponseDetailExtinguisherClient { Errors = errors });
            }
            else
            {
                var response = await serviceDetailExtinguisherClients.CreateDetailClient( request );

                return Ok( response );
            }
        }

        [HttpPut("update-by/{idDetail}")]
        public async Task<IActionResult> UpdateDetailClient( Guid idDetail, BaseDetailExtinguisherClient request )
        {
            var Validacion = validator.Validate( request );

            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select( error => error.ErrorMessage );

                return BadRequest(new RespuestaCredito { Errors = errors });
            }
            else
            {
                var response = await serviceDetailExtinguisherClients.UpdateDetailClient( idDetail, request );

                return Ok(response);
            }
        }

        [HttpDelete("delete-by/{idDetail}")]
        public async Task<IActionResult> DeleteDetailExtinguisherClient( Guid idDetail )
        {
            var response = await serviceDetailExtinguisherClients.DeleteDetailClient( idDetail );

            return Ok( response );
        }

    }
}
