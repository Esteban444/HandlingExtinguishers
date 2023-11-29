using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using HandlingExtinguishers.Infrastructure.Repositories;

namespace MHandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositoryDetailService : BaseRepository<DetailService>, IRepositoryDetailService
    {
        public RepositoryDetailService(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
