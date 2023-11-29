using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using HandlingExtinguishers.Infrastructure.Repositories;

namespace HandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositoryDetailExtinguisherClient : BaseRepository<DetailExtinguisherClient>, IRepositoryDetailExtinguisherClient
    {
        public RepositoryDetailExtinguisherClient(HandlingExtinguisherContext context) : base(context)
        {

        }
    }
}
