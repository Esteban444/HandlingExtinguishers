namespace HandlingExtinguishers.Contracts.Interfaces.Services;

using HandlingExtinguishers.Models.Filters;
using HandlingExtinguishers.Models.Inventories;

public interface IInventoryService
{
    Task<IEnumerable<InventarioRequest>> SearchInventories( FilterInventory filter );

    Task<InventarioRequest> SearchInventoryById( Guid inventoryId ); 

    Task<InventarioRequest> CreateInventory( InventarioRequest inventario );

    Task<InventarioRequest> UpdateInventory( Guid inventoriId, InventarioRequest inventario );

    Task<InventarioRequest> DeleteInventory( Guid inventoriId );
}
