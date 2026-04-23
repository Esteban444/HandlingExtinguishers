namespace HandlingExtinguishers.Controllers;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Clients;
using HandlingExtinguishers.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endregion

[Route("api/detail-extinguisher-client")]
[ApiController]
[Authorize]
public class DetailExtinguisherClientController( IServiceDetailExtinguisherClients serviceDetailExtinguisherClients,
                                                 IValidator<DetailExtinguisherClientRequest> validator ) : ControllerBase
{
    private readonly IServiceDetailExtinguisherClients serviceDetailExtinguisherClients = serviceDetailExtinguisherClients;
    private readonly IValidator<DetailExtinguisherClientRequest> validator = validator;

    [HttpGet("search")]
    public async Task<IActionResult> SearchDetailClients( [FromQuery] FilterDetailExtClient filter )
    {
        var response = await serviceDetailExtinguisherClients.SearchDetailClients( filter );

        return Ok( response );
    }

    [HttpGet("search-by/{idDetail}")]
    public async Task<IActionResult> SearchDetailClientById( Guid idDetail )
    {
        var response = await serviceDetailExtinguisherClients.SearchDetailClientById( idDetail );

        return Ok( response );
    }

    [HttpPost]
    public async Task<IActionResult> CreateDetailExtinguisher( [FromBody] DetailExtinguisherClientRequest request )
    {
        var Validacion = validator.Validate( request );

        if ( !Validacion.IsValid )
        {
            var errors = Validacion.Errors.Select(error => error.ErrorMessage);

            return BadRequest(new ErrorResponse { Errors = errors });
        }
        else
        {
            var response = await serviceDetailExtinguisherClients.CreateDetailClient( request );

            return Ok( response );
        }
    }

    [HttpPut("update-detail-by/{idDetail}")]
    public async Task<IActionResult> UpdateDetailClient( Guid idDetail, DetailExtinguisherClientRequest request )
    {
        var Validacion = validator.Validate( request );

        if (!Validacion.IsValid)
        {
            var errors = Validacion.Errors.Select( error => error.ErrorMessage );

            return BadRequest(new ErrorResponse { Errors = errors });
        }
        else
        {
            var response = await serviceDetailExtinguisherClients.UpdateDetailClient( idDetail, request );

            return Ok(response);
        }
    }

    [HttpDelete("delete-detail-by/{idDetail}")]
    public async Task<IActionResult> DeleteDetailExtinguisherClient( Guid idDetail )
    {
        var response = await serviceDetailExtinguisherClients.DeleteDetailClient( idDetail );

        return Ok( response );
    }

}
