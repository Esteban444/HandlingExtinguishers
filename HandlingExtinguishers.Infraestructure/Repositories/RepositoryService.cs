using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace HandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositoryService : BaseRepository<Service>, IRepositoryService
    {
        public RepositoryService(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
