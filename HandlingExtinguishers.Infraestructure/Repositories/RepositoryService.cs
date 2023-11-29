using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using HandlingExtinguishers.Infrastructure.Repositories;

namespace HandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositoryService : BaseRepository<Service>, IRepositoryService
    {
        public RepositoryService(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
