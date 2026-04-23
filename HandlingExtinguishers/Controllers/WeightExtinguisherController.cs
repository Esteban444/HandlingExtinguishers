namespace HandlingExtinguishers.Controllers;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Extinguishers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endregion

[Route("api-weight-extinguisher")]
[ApiController]
[Authorize]
public class WeightExtinguisherController( IWeightExtinguisherService serviceWeightExtinguisher, 
                                           IValidator<WightExtinguisherRequest> validator) : ControllerBase
{
    private readonly IWeightExtinguisherService serviceWeightExtinguisher = serviceWeightExtinguisher;
    private readonly IValidator<WightExtinguisherRequest> validator = validator;

    [HttpGet("searchs")]
    public async Task<IActionResult> SearchWeightExtinguishers() 
    {
        var response = await serviceWeightExtinguisher.SearchWeightExtinguishers();

        return Ok( response );
    }

    [HttpGet("search-by/{idWeightExtinguisher}")]
    public async Task<IActionResult> SearchWeightExtinguisherById(Guid idWeightExtinguisher )
    {
        var response = await serviceWeightExtinguisher.SearchWeightExtinguisherById( idWeightExtinguisher );

        return Ok(response);
    }

    [HttpPost("create-weight-extinguisher")]
    public async Task<IActionResult> CreateWeightExtinguisher( WightExtinguisherRequest request )
    {
        var Validation = validator.Validate( request );

        if ( !Validation.IsValid )
        {
            var errors = Validation.Errors.Select( error => error.ErrorMessage );

            return BadRequest(new ErrorResponse { Errors = errors });
        }
        else
        {
            var response = await serviceWeightExtinguisher.CreateWeightExtinguisher( request );

            return Ok( response );
        }
    }

    [HttpPut("update-weight-extinguisher-by/{weightExtinguisherId}")]
    public async Task<IActionResult> UpdateWeightExtinguisher( Guid weightExtinguisherId, WightExtinguisherRequest request )
    {
        var Validation = validator.Validate( request );

        if ( !Validation.IsValid )
        {
            var errors = Validation.Errors.Select( error => error.ErrorMessage );

            return BadRequest( new ErrorResponse { Errors = errors } );
        }
        else
        {
            var response = await serviceWeightExtinguisher.UpdateWeightExtinguisher( weightExtinguisherId, request );

            return Ok( response );
        }
    }

    [HttpDelete("delete-weight-extinguisher-by/{weightExtinguisherId}")]
    public async Task<IActionResult> DeletedWeightEstinguisher( Guid weightExtinguisherId )
    {
        var response = await serviceWeightExtinguisher.DeleteWeightExtinguisher( weightExtinguisherId );

        return Ok( response );

    }
}
