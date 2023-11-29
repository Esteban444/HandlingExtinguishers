using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using HandlingExtinguishers.Infrastructure.Repositories;

namespace HandlingExtinguishers.Infraestructure.Repositories
{
    public class RepositoryClient : BaseRepository<Client>, IRepositoryClient
    {
        public RepositoryClient(HandlingExtinguisherContext context) : base(context)
        {
        }

    }
}
