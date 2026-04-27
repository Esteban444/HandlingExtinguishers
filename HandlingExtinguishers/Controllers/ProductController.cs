namespace HandlingExtinguishers.Controllers;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endregion

[Route("api/product")]
[ApiController]
[Authorize]
public class ProductController( IProductService productService, IValidator<ProductRequest> validator ) : ControllerBase
{
    private readonly IProductService productService = productService;
    private readonly IValidator<ProductRequest> validator = validator;

    [HttpGet("search")]
    public async Task<IActionResult> SearchProduct( [FromQuery] FilterProduct filter )
    {
        var response = await productService.SearchProduct( filter );

        return Ok( response );
    }

    [HttpGet("search-by/{productId}")]
    public async Task<IActionResult> SearchProductById( Guid productId )
    {
        var response = await productService.SearchProductById( productId );

        return Ok( response );
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProduct( ProductRequest request )
    {
        var validation = validator.Validate( request );

        if ( !validation.IsValid )
        {
            var errors = validation.Errors.Select( error => error.ErrorMessage );

            return BadRequest( new ErrorResponse { Errors = errors } );
        }
        else
        {
            var response = await productService.CreateProduct( request );

            return Ok( response );
        }
    }

    [HttpPut("update-by/{productId}")]
    public async Task<IActionResult> UpdateProduct( Guid productId, ProductRequest request )
    {
        var validation = validator.Validate( request );

        if ( !validation.IsValid )
        {
            var errors = validation.Errors.Select( error => error.ErrorMessage );

            return BadRequest(new ErrorResponse { Errors = errors });
        }
        else
        {
            var response = await productService.UpdateProduct( productId, request );

            return Ok( response );
        }
    }

    [HttpDelete("delete-by/{productId}")]
    public async Task<IActionResult> DeleteProduct( Guid productId )
    {
        var response = await productService.DeleteProduct( productId );

        return Ok( response );

    }
}
