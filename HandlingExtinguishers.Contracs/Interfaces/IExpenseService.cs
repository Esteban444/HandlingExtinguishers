using HandlingExtinguishers.Models.Expenses;
using HandlingExtinguishers.Models.Filters;

namespace HandlingExtinguishers.Contracts.Interfaces
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseResponse>> SearchExpense( FilterExpense filters );

        Task<ExpenseResponse> SearchExpenseById( Guid expenseId );

        Task<ExpenseResponse> CreateExpense( ExpenseRequest request );

        Task<ExpenseResponse> UpdateExpense( Guid expenseId, ExpenseRequest request );

        Task<ExpenseResponse> DeleteExpense( Guid expenseId );    
    }
}