using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace MHandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositoryDetailService : BaseRepository<DetailService>, IRepositoryDetailService
    {
        public RepositoryDetailService(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
