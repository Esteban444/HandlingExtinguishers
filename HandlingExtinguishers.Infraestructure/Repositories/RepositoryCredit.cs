using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using HandlingExtinguishers.Infrastructure.Repositories;

namespace MHandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositoryCredit : BaseRepository<CreditService>, IRepositoryCredit
    {
        public RepositoryCredit(HandlingExtinguisherContext context) : base(context)
        {
        }
    }
}
