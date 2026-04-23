using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace MHandlingExtinguishers.Infraestructura.Repositorios
{
    public class CreditRepository : BaseRepository<CreditService>, ICreditServiceRepository
    {
        public CreditRepository(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
