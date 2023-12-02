using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace HandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositoryDetailExtinguisherClient : BaseRepository<DetailExtinguisherClient>, IRepositoryDetailExtinguisherClient
    {
        public RepositoryDetailExtinguisherClient(HandlingExtinguisherContext context) : base(context)
        {

        }
    }
}
