
namespace HandlingExtinguishers.Controllers;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Clients;
using HandlingExtinguishers.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endregion

[Route("api/client")]
[ApiController]
[Authorize]
public class ClientController( IClientService client, IValidator<ClientRequest> validator ) : ControllerBase
{
    private readonly IClientService serviceClient = client;
    private readonly IValidator<ClientRequest> validator = validator;

    [HttpGet("search-clients")]
    public async Task<IActionResult> Searchs( [FromQuery] FilterClient filter )
    {
        var response = await serviceClient.SearchClients( filter );

        return Ok( response );
    }

    [HttpGet("search-client-by/{clientId}")]
    public async Task<IActionResult> Search( Guid clientId )
    {
        var response = await serviceClient.SearchClientById( clientId );

        return Ok( response );
    }

    [HttpPost("crate")]
    public async Task<IActionResult> Create( ClientRequest client )
    {
        var Validation = validator.Validate( client );

        if ( !Validation.IsValid )
        {
            var errors = Validation.Errors.Select(e => e.ErrorMessage);

            return BadRequest( new ErrorResponse { Errors = errors } );
        }
        else
        {
            var response = await serviceClient.CreateClient( client );

            return Ok( response );
        }
    }

    [HttpPut("update-client-by/{clientId}")]
    public async Task<IActionResult> UpdateClient( Guid clientId, ClientRequest request )
    {
        var Validation = validator.Validate( request );

        if ( !Validation.IsValid )
        {
            var errors = Validation.Errors.Select(e => e.ErrorMessage);

            return BadRequest( new ErrorResponse { Errors = errors } );
        }
        else
        {
            var response = await serviceClient.UpdateClient( clientId, request );

            return Ok( response );
        }
    }

    [HttpDelete("delete-client-by/{clientId}")]
    public async Task<IActionResult> DeleteClient( Guid clientId )
    {
        var response = await serviceClient.DeleteClient( clientId );

        return Ok( response );

    }
}
