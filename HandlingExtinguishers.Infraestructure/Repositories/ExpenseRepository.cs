using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Infrastructure.Repositories;
using HandlingExtinguishers.Models.Models;

namespace MHandlingExtinguishers.Infraestructura.Repositorios
{
    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(HandlingExtinguisherContext context) : base(context)
        {

        }
    }
}
