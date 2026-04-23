using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace HandlingExtinguishers.Infraestructure.Repositories
{
    public class PriceRepository : BaseRepository<Price>, IPriceRepository
    {
        public PriceRepository(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
