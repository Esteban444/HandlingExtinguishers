namespace HandlingExtinguishers.Infraestructure.Repositories;

#region Usings
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Models.Models;
#endregion

public class ServiceRepository : BaseRepository<Service>, IServiceRepository
{
    public ServiceRepository(HandlingExtinguisherContext context) : base(context)
    {
    }
}
