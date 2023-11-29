using HandlingExtinguisher.Infraestructure.Data;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Dto.Models;
using HandlingExtinguishers.Infrastructure.Repositories;

namespace MHandlingExtinguishers.Infraestructura.Repositorios
{
    public class RepositoryExpense : BaseRepository<Expense>, IRepositoryExpense
    {
        public RepositoryExpense(HandlingExtinguisherContext context) : base(context)
        {

        }
    }
}
