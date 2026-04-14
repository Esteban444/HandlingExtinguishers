using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace MHandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositoryCredit : BaseRepository<CreditService>, IRepositoryCredit
    {
        public RepositoryCredit(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
