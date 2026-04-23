namespace HandlingExtinguishers.Controllers;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Prices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endregion

[Route("api/price")]
[ApiController]
[Authorize]
public class PriceController(IPriceService priceService, IValidator<PriceRequest> validator) : ControllerBase
{
    private readonly IPriceService priceService = priceService;
    private readonly IValidator<PriceRequest> validator = validator;

    [HttpGet("search")]
    public async Task<IActionResult> SearchPrice( [FromQuery] FilterPrices filter )
    {
        var response = await priceService.SearchPrices( filter );

        return Ok( response );
    }

    [HttpGet("search-by/{priceId}")]
    public async Task<IActionResult> SearchPriceById( Guid priceId )
    {
        var response = await priceService.SearchPriceById( priceId );

        return Ok( response );
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrice( PriceRequest request )
    {
        var Validation = validator.Validate( request );

        if ( !Validation.IsValid ) 
        {
            var errors = Validation.Errors.Select(error => error.ErrorMessage);

            return BadRequest( new ErrorResponse { Errors = errors } );
        }
        else
        {
            var response = await priceService.CreatePrice( request );

            return Ok( response );
        }
    }

    [HttpPut("update-by/{priceId}")]
    public async Task<IActionResult> UpdatePrice(Guid priceId, PriceRequest request)
    {
        var validation = validator.Validate( request );

        if ( !validation.IsValid )
        {
            var errors = validation.Errors.Select(e => e.ErrorMessage);

            return BadRequest(new ErrorResponse { Errors = errors });
        }
        else
        {
            var response = await priceService.UpdatePrice( priceId, request );

            return Ok( response );
        }
    }

    [HttpDelete("delete-by/{priceId}")]
    public async Task<IActionResult> DeletePrice( Guid priceId )
    {
        var response = await priceService.DeletePrice( priceId );

        return Ok( response );
    }
}
