namespace HandlingExtinguishers.Controllers;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Extinguishers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endregion

[Route("api-type-extinguisher")]
[ApiController]
[Authorize]
public class TypeExtinguisherController( ITypeExtinguisherService typeExtinguisherService, 
                                         IValidator<TypeExtinguisherRequest> validator) : ControllerBase
{
    private readonly ITypeExtinguisherService typeExtinguisherService = typeExtinguisherService;
    private readonly IValidator<TypeExtinguisherRequest> validator = validator;

    [HttpGet("searchs")]
    public async Task<IActionResult> Searchs()
    {
        var response = await typeExtinguisherService.SearchTypeExtinguisher();

        return Ok( response );
    }

    [HttpGet("search-by/{typeExtinguisherId}")]
    public async Task<IActionResult> SearchTypeExtinguisherById( Guid typeExtinguisherId )
    {
        var response = await typeExtinguisherService.SearchTypeExtinguisherById( typeExtinguisherId );

        return Ok( response );
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTypeExtinguisher( TypeExtinguisherRequest request )
    {
        var Validacion = validator.Validate( request );

        if ( !Validacion.IsValid )
        {
            var errors = Validacion.Errors.Select( error => error.ErrorMessage );

            return BadRequest( new ErrorResponse { Errors = errors } );
        }
        else
        {
            var response = await typeExtinguisherService.CreateTypeExtinguisher( request );

            return Ok( response );
        }
    }

    [HttpPut("update-by/{typeExtinguisherId}")]
    public async Task<IActionResult> UpdateTypeExtinguisher( Guid typeExtinguisherId, TypeExtinguisherRequest request )
    {
        var validation = validator.Validate( request );

        if ( !validation.IsValid )
        {
            var errors = validation.Errors.Select( error => error.ErrorMessage );

            return BadRequest( new ErrorResponse { Errors = errors } );
        }
        else
        {
            var response = await typeExtinguisherService.UpdateTypeExtinguisher( typeExtinguisherId, request );

            return Ok( response );
        }
    }

    [HttpDelete("delete-by/{typeExtinguisherId}")]
    public async Task<IActionResult> DeleteTypeExtinguisher( Guid typeExtinguisherId )
    {
        var response = await typeExtinguisherService.DeleteTypeExtinguisher( typeExtinguisherId );

        return Ok( response );
    }
}
