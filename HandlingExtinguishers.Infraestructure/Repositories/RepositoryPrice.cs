using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using HandlingExtinguishers.Infrastructure.Repositories;

namespace MHandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositoryPrice : BaseRepository<Price>, IRepositoryPrice
    {
        public RepositoryPrice(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
