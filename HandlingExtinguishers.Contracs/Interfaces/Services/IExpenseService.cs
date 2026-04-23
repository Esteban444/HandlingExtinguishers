using HandlingExtinguishers.Models.Expenses;
using HandlingExtinguishers.Models.Filters;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseResponse>> SearchExpense( FilterExpense filters );

        Task<ExpenseResponse> SearchExpenseById( Guid idExpense );

        Task<ExpenseResponse> CreateExpense( ExpenseRequest request );

        Task<ExpenseResponse> UpdateExpense( Guid idExpense, ExpenseRequest request );

        Task<ExpenseResponse> DeleteExpense( Guid idExpense  );    
    }
}