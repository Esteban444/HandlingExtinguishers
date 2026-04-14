using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace HandlingExtinguishers.Infraestructure.Repositories
{
    public class RepositoryClient : BaseRepository<Client>, IRepositoryClient
    {
        public RepositoryClient(HandlingExtinguisherContext context) : base(context)
        {
        }

    }
}
