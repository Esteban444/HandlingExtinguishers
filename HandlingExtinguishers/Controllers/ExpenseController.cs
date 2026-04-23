namespace HandlingExtinguishers.Controllers;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Expenses;
using HandlingExtinguishers.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endregion


[Route("api/expense")]
[ApiController]
[Authorize]
public class ExpenseController( IExpenseService expenseService, IValidator<ExpenseRequest> validator ) : ControllerBase
{

    private readonly IExpenseService expenseService = expenseService;
    private readonly IValidator<ExpenseRequest> validator = validator;

    [HttpGet("search")]
    public async Task<IActionResult> SearchExpense( [FromQuery] FilterExpense filter )
    {
        var response = await expenseService.SearchExpense( filter );

        return Ok( response );
    }

    [HttpGet("search-by/{idExpense}")]
    public async Task<IActionResult> SearchExpenseById( Guid idExpense )
    {
        var response = await expenseService.SearchExpenseById( idExpense );

        return Ok(response);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateExpense( ExpenseRequest request )
    {
        var Validacion = validator.Validate( request );

        if ( !Validacion.IsValid )
        {
            var errors = Validacion.Errors.Select( error => error.ErrorMessage );

            return BadRequest( new ErrorResponse { Errors = errors } );
        }
        else
        {
            var response = await expenseService.CreateExpense( request );

            return Ok( response );
        }
    }

    [HttpPut("update-by/{idExpense}")]
    public async Task<IActionResult> UpdateExpernse( Guid idExpense, ExpenseRequest request )
    {
        var Validacion = validator.Validate( request );

        if ( !Validacion.IsValid )
        {
            var errors = Validacion.Errors.Select( error => error.ErrorMessage );

            return BadRequest( new ErrorResponse { Errors = errors } );
        }
        else
        {
            var response = await expenseService.UpdateExpense( idExpense, request );

            return Ok( response );
        }
    }

    [HttpDelete("delete-by/{idExpense}")]
    public async Task<IActionResult> DeleteExpense(Guid idExpense)
    {
        var response = await expenseService.DeleteExpense( idExpense );

        return Ok( response );

    }
}
