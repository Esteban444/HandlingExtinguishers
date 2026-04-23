namespace HandlingExtinguishers.Infraestructure.Repositories;

using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
{
    public InventoryRepository(HandlingExtinguisherContext context) : base(context)
    {
    }
}
