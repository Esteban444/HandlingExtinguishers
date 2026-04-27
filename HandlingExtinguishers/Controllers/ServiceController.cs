namespace HandlingExtinguishers.Controllers;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Services;
using Microsoft.AspNetCore.Mvc;
# endregion

[Route("api/service")]
[ApiController]
public class ServiceController( IServiceOfService service, IValidator<ServiceRequest> validator ) : ControllerBase
{
    private readonly IServiceOfService service = service;
    private readonly IValidator<ServiceRequest> validator = validator;

    [HttpGet("search")]
    public async Task<IActionResult> ConsultaServicios( [FromQuery] FilterService filter )
    {
        var response = await service.SearchServices( filter );

        return Ok( response );
    }

    [HttpGet("search-by/{serviceId}")]
    public async Task<IActionResult> SearchById( Guid serviceId )
    {
        var response = await service.SearchServiceById( serviceId );

        return Ok( response );
    }

    [HttpPost("create-detail")]
    public async Task<IActionResult> CreateServiceDetail( ServiceRequest request )
    {
        var Validation = validator.Validate( request );

        if ( !Validation.IsValid )
        {
            var errors = Validation.Errors.Select( error => error.ErrorMessage );

            return BadRequest( new ErrorResponse { Errors = errors } );
        }
        else
        {
            var response = await service.CreateServiceDetail( request );

            return Ok( response );
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateService( ServiceRequest request )
    {
        var Validacion = validator.Validate( request );

        if ( !Validacion.IsValid )
        {
            var errors = Validacion.Errors.Select( error => error.ErrorMessage );

            return BadRequest( new ErrorResponse { Errors = errors } );
        }
        else
        {
            var response = await service.CreateService( request );

            return Ok( response );
        }
    }

    [HttpPut("update-status")]
    public async Task<IActionResult> UpdateStatus( Guid serviceId, EditStatus request)
    {
        var response = await service.UpdateStatus( serviceId, request );

        return Ok( response );
    }

    [HttpPut("update-by/{serviceId}")]
    public async Task<IActionResult> UpdateService( Guid serviceId, ServiceRequest request )
    {
        var Validation = validator.Validate( request );

        if ( !Validation.IsValid )
        {
            var errors = Validation.Errors.Select( error => error.ErrorMessage );

            return BadRequest( new ErrorResponse { Errors = errors } );
        }
        else
        {
            var response = await service.UpdateService( serviceId, request );

            return Ok( response );
        }
    }

    [HttpDelete("delete-by/{serviceId}")]
    public async Task<IActionResult> DeleteService( Guid serviceId )
    {
        var response = await service.DeleteService( serviceId );

        return Ok( response );
    }
}
