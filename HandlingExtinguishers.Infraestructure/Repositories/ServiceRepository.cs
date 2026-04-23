using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace HandlingExtinguishers.Infraestructura.Repositorios
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
