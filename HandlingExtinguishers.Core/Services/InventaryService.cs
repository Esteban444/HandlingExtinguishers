namespace HandlingExtinguishers.Core.Services;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Inventories;
using HandlingExtinguishers.Models.Models;
using Microsoft.EntityFrameworkCore;
#endregion

public class InventaryService( IInventoryRepository repositoryInventory, IMapper mapper ) : IInventoryService
{
    private readonly IMapper mapper = mapper;
    private readonly IInventoryRepository repositoryInventory = repositoryInventory;

    public async Task<IEnumerable<InventarioRequest>> SearchInventories( FilterInventory filter )
    {
        var result = await repositoryInventory.GetAll().ToListAsync();

        var response = mapper.Map<IEnumerable<InventarioRequest>>( result );

        return response;
    }

    public async Task<InventarioRequest> SearchInventoryById( Guid inventoryId )
    {
        var result = await repositoryInventory.FindBy(i => i.InventoryId == inventoryId ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            return mapper.Map<InventarioRequest>( result );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.InventoryNotFound );
        }
    }

    public async Task<InventarioRequest> CreateInventory( InventarioRequest request )
    {
        var result = mapper.Map<Inventory>( request );

        await repositoryInventory.Add( result );

        var response = mapper.Map<InventarioRequest>( result );

        return response;
    }

    public async Task<InventarioRequest> UpdateInventory( Guid inventoryId, InventarioRequest request )
    {
        var result = await repositoryInventory.FindBy(i => i.InventoryId == inventoryId).FirstOrDefaultAsync();

        if ( result is not null ) 
        {
            result.ProductId = request.ProductId;
            result.Date = request.Date;
            result.Description = request.Description;
            result.TypeExtinguisherId = request.TypeExtinguisherId;
            result.WeightExtinguisherId = request.WeightExtinguisherId;
            result.Quantity = request.Quantity;
            result.ExpirationDate = request.ExpirationDate;

            await repositoryInventory.Update( result );

            var response = mapper.Map<InventarioRequest>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.InventoryNotFound );
        }
    }

    public async Task<InventarioRequest> DeleteInventory( Guid inventoryId )
    {
        var result = await repositoryInventory.FindBy(inventory => inventory.InventoryId == inventoryId).FirstOrDefaultAsync();

        if ( result is not null )
        {
            try
            {
                await repositoryInventory.Delete( result );

                var response = mapper.Map<InventarioRequest>( result  );

                return response;
            }
            catch ( Exception )
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.RelatedInventory );
            }
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.InventoryNotFound );
        }
    }

}
