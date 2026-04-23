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

public class ExpenseService( IExpenseRepository repository, IMapper mapper ) : IExpenseService
{
    private readonly IExpenseRepository repository = repository;
    private readonly IMapper mapper = mapper;

    public async Task<IEnumerable<ExpenseResponse>> SearchExpense( FilterExpense filters )
    {
        var result = await repository.GetAll().ToListAsync();

        var response = mapper.Map<IEnumerable<ExpenseResponse>>( result );

        return response;
    }

    public async Task<ExpenseResponse> SearchExpenseById( Guid idExpense )
    {
        var result = await repository.FindBy( expense => expense.ExpenseId == idExpense ).FirstOrDefaultAsync();

        if ( result is not null)
        {
            return mapper.Map<ExpenseResponse>( result );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ExpenseNotFound );
        }
    }

    public async Task<ExpenseResponse> CreateExpense( ExpenseRequest request )
    {
        var result = mapper.Map<Models.Models.Expense>( request );

        await repository.Add( result );

        var response = mapper.Map<ExpenseResponse>( result );

        return response;
    }

    public async Task<ExpenseResponse> UpdateExpense( Guid idExpense, ExpenseRequest request )
    {
        var result = await repository.FindBy( expense => expense.ExpenseId == idExpense).FirstOrDefaultAsync();

        if ( result is not null )
        {
            result.Description = request.Description;
            result.Date = request.Date;
            result.Quantity = request.Quantity;
            result.Total = request.Total;

            await repository.Update( result );

            var response = mapper.Map<ExpenseResponse>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ExpenseNotFound );
        }
    }

    public async Task<ExpenseResponse> DeleteExpense( Guid idExpense )
    {
        var result = await repository.FindBy( expense => expense.ExpenseId == idExpense).FirstOrDefaultAsync();

        if ( result is not null )
        {
            await repository.Delete( result );

            var response = mapper.Map<ExpenseResponse>( result );

            return response;
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.ExpenseNotFound );
        }
    }
}
