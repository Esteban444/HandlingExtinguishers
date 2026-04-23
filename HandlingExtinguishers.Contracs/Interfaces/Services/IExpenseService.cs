using HandlingExtinguishers.Models.Expenses;
using HandlingExtinguishers.Models.Filters;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseRequest>> SearchExpense( FilterExpense filters );
        Task<ExpenseRequest> SearchExpenseById( Guid idExpense );
        Task<ExpenseRequest> CreateExpense( ExpenseRequest request );
        Task<ExpenseRequest> UpdateExpense( Guid idExpense, ExpenseRequest request );
        Task<ExpenseRequest> DeleteExpense( Guid idExpense  );    
    }
}