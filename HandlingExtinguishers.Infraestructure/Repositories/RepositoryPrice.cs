using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace MHandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositoryPrice : BaseRepository<Price>, IRepositoryPrice
    {
        public RepositoryPrice(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
