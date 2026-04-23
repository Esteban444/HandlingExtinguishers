namespace HandlingExtinguishers.Core.Services;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Expenses;
using HandlingExtinguishers.Models.Filters;
using Microsoft.EntityFrameworkCore;
#endregion

public class ExpenseService( IRepositoryExpense repository, IMapper mapper ) : IExpenseService
{
    private readonly IRepositoryExpense repository = repository;
    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<ExpenseRequest>> SearchExpense( FilterExpense filters )
    {
        var result = await repository.GetAll().ToListAsync();

        var response = mapper.Map<IEnumerable<ExpenseRequest>>( result );

        return response;
    }

    public async Task<ExpenseRequest> SearchExpenseById( Guid idExpense )
    {
        var result = await repository.FindBy( expense => expense.ExpenseId == idExpense ).FirstOrDefaultAsync();

        if ( result is not null)
        {
            return mapper.Map<ExpenseRequest>( result );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ExpenseNotFound );
        }
    }

    public async Task<ExpenseRequest> CreateExpense( ExpenseRequest request )
    {
        var result = mapper.Map<Models.Models.Expense>( request );

        await repository.Add( result );

        var response = mapper.Map<ExpenseRequest>( result );

        return response;
    }

    public async Task<ExpenseRequest> UpdateExpense( Guid idExpense, ExpenseRequest request )
    {
        var result = await repository.FindBy( expense => expense.ExpenseId == idExpense).FirstOrDefaultAsync();

        if ( result is not null )
        {
            result.Description = request.Description;
            result.Date = request.Date;
            result.Quantity = request.Quantity;
            result.Total = request.Total;

            await repository.Update( result );

            var response = mapper.Map<ExpenseRequest>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ExpenseNotFound );
        }
    }

    public async Task<ExpenseRequest> DeleteExpense( Guid idExpense )
    {
        var result = await repository.FindBy( expense => expense.ExpenseId == idExpense).FirstOrDefaultAsync();

        if ( result is not null )
        {
            await repository.Delete( result );

            var response = mapper.Map<ExpenseRequest>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ExpenseNotFound );
        }
    }
}
