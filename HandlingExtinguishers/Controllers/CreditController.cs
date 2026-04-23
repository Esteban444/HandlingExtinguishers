namespace HandlingExtinguishers.Controllers;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Credit;
using HandlingExtinguishers.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endregion


[Route("[controller]")]
[ApiController]
[Authorize]
public class CreditController( ICreditService servicioCredit, IValidator<CreditServiceRequest> validator ) : ControllerBase
{
    private readonly ICreditService serviciCredit = servicioCredit;
    private readonly IValidator<CreditServiceRequest> validator = validator;

    [HttpGet("search-credits")]
    public async Task<IActionResult>SearchCredit( [FromQuery] FilterCredit filter )
    {
        var response = await serviciCredit.SearchCredits( filter );

        return Ok( response );
    }

    [HttpGet("search-credit-by{id}")]
    public async Task<IActionResult> SearchById( Guid idCredit )
    {
        var response = await serviciCredit.SearchCreditById( idCredit );

        return Ok( response );
    }

    [HttpPost("create-credit")]
    public async Task<IActionResult> CreateCredit( CreditServiceRequest request )
    {
        var Validacion = validator.Validate( request );

        if ( !Validacion.IsValid )
        {
            var errors = Validacion.Errors.Select( error => error.ErrorMessage);

            return BadRequest(new ErrorResponse { Errors = errors });
        }
        else
        {
            var response = await serviciCredit.CreateCredit( request );

            return Ok( response );
        }
    }

    [HttpPut("update-credit-by/{idCredit}")]
    public async Task<IActionResult> UpdateCredit(Guid idCredit, CreditServiceRequest request )
    {
        var validation = validator.Validate( request );

        if ( !validation.IsValid )
        {
            var errors = validation.Errors.Select( error => error.ErrorMessage );

            return BadRequest( new ErrorResponse { Errors = errors } );
        }
        else
        {
            var response = await serviciCredit.UpdateCredit( idCredit, request );

            return Ok( response );
        }
    }

    [HttpDelete("delete-credit-by/{idCredit}")]
    public async Task<IActionResult> DeleteCredit(Guid idCredit)
    {
        var response = await serviciCredit.DeleteCredit( idCredit );

        return Ok(response);
    }
}
