namespace HandlingExtinguishers.Controllers;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.CommandServices;
using HandlingExtinguishers.Contracts.Interfaces.QueryServices;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Services;
using Microsoft.AspNetCore.Mvc;
# endregion

[Route("api/service")]
[ApiController]
public class ServiceController( IServiceQueryService serviceQueryService,
                                IServiceCommandService commandService,
                                IValidator<ServiceRequest> validator ) : ControllerBase
{
    private readonly IServiceQueryService serviceQueryService = serviceQueryService;
    private readonly IServiceCommandService commandService = commandService;
    private readonly IValidator<ServiceRequest> validator = validator;

    [HttpGet("search")]
    public async Task<IActionResult> ConsultaServicios( [FromQuery] FilterService filter )
    {
        var response = await serviceQueryService.SearchServices( filter );

        return Ok( response );
    }

    [HttpGet("search-by/{serviceId}")]
    public async Task<IActionResult> SearchById( Guid serviceId )
    {
        var response = await serviceQueryService.SearchServiceById( serviceId );

        return Ok( response );
    }

    [HttpPost("create")]
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
            var response = await commandService.CreateService( request );

            return Ok( response );
        }
    }

    [HttpPut("update-status")]
    public async Task<IActionResult> UpdateStatus( Guid serviceId, EditStatus request)
    {
        var response = await commandService.UpdateStatus( serviceId, request );

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
            var response = await commandService.UpdateService( serviceId, request );

            return Ok( response );
        }
    }

    [HttpDelete("delete-by/{serviceId}")]
    public async Task<IActionResult> DeleteService( Guid serviceId )
    {
        var response = await commandService.DeleteService( serviceId );

        return Ok( response );
    }
}
