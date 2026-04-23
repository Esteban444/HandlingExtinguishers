namespace HandlingExtinguishers.Controllers;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Inventories;
using ManagementFireEstinguisher.Dto.Inventories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endregion

[Route("api/inventory")]
[ApiController]
[Authorize]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService inventoryService;
    private readonly IValidator<InventarioRequest> validator;

    public InventoryController( IInventoryService inventoryService, IValidator<InventarioRequest> validator )
    {
        this.inventoryService = inventoryService;
        this.validator = validator;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchInventories( [FromQuery] FilterInventory filter )
    {
        var response = await inventoryService.SearchInventories( filter );

        return Ok( response );
    }

    [HttpGet("search-by/{inventoryId}")]
    public async Task<IActionResult> GetInventoryById( Guid inventoryId )
    {

        var response = await inventoryService.SearchInventoryById( inventoryId );

        return Ok( response );
    }

    [HttpPost]
    public async Task<IActionResult> CreateInventory( InventarioRequest request )
    {
        var Validacion = validator.Validate( request );

        if ( !Validacion.IsValid )
        {
            var errors = Validacion.Errors.Select( error => error.ErrorMessage );

            return BadRequest( new InventaryResponse { Errors = errors } );
        }
        else
        {
            var response = await inventoryService.CreateInventory( request );

            return Ok( response );
        }
    }

    [HttpPut("update-by/{inventoryId}")]
    public async Task<IActionResult> UpdateInventory( Guid inventoryId, InventarioRequest request )
    {
        var Validacion = validator.Validate( request );

        if ( !Validacion.IsValid )
        {
            var errors = Validacion.Errors.Select( error => error.ErrorMessage );

            return BadRequest(new InventaryResponse { Errors = errors });
        }
        else
        {
            var response = await inventoryService.UpdateInventory( inventoryId, request );

            return Ok( response );
        }
    }

    [HttpDelete("delete-by/{inventoryId}")]
    public async Task<IActionResult> DeleteInventory(Guid inventoryId)
    {
        var response = await inventoryService.DeleteInventory( inventoryId );

        return Ok( response );

    }
}
