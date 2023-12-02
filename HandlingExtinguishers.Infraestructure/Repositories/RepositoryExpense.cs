using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace MHandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositoryExpense : BaseRepository<Expense>, IRepositoryExpense
    {
        public RepositoryExpense(HandlingExtinguisherContext context) : base(context)
        {

        }
    }
}
