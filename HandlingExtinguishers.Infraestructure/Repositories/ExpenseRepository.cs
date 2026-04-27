namespace HandlingExtinguishers.Infraestructure.Repositories;

#region
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Infraestructure.Data;
using HandlingExtinguishers.Models.Models;
#endregion

public class ExpenseRepository( HandlingExtinguisherContext context ) : BaseRepository<Expense>( context ), IExpenseRepository
{
}
