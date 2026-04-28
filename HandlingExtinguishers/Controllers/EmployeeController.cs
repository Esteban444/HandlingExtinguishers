namespace HandlingExtinguishers.Controllers;

#region Usings
using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.CommandServices;
using HandlingExtinguishers.Contracts.Interfaces.QueryServices;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endregion


[Route("api/employee")]
[ApiController]
[Authorize]
public class EmployeeController( IEmployeeQueryService employeeQueryService,
                                 IEmployeeCommandService employeeCommandService,
                                 IValidator<EmployeeRequest> validator ) : ControllerBase
{
    private readonly IEmployeeQueryService queryService = employeeQueryService;
    private readonly IEmployeeCommandService commandService = employeeCommandService;

    [HttpGet("search")]
    [ProducesResponseType(typeof(FilterEmployeeResponse), 200)]
    [ProducesResponseType(typeof(FailedOperationResult), 404)]
    [ProducesResponseType(typeof(FailedOperationResult), 400)]
    public async Task<IActionResult> Employees([FromQuery] QueryParameter filter)
    {
        var response = await queryService.SearchEmployees(filter);
        return Ok(response);
    }

    [HttpGet("search-by/{employeeId}")]
    [ProducesResponseType(typeof(EmployeeResponse), 200)]
    [ProducesResponseType(typeof(FailedOperationResult), 404)]
    [ProducesResponseType(typeof(FailedOperationResult), 400)]
    public async Task<IActionResult> EmployeeById( Guid employeeId )
    {
        var response = await queryService.SearchEmployeeById( employeeId );

        return Ok( response );
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(EmployeeResponse), 200)]
    [ProducesResponseType(typeof(FailedOperationResult), 404)]
    [ProducesResponseType(typeof(FailedOperationResult), 400)]
    public async Task<IActionResult> CreateEmployee( EmployeeRequest request )
    {
        var Validacion = validator.Validate( request );

        if ( !Validacion.IsValid )
        {
            var errors = Validacion.Errors.Select( error => error.ErrorMessage );

            return BadRequest( new ErrorResponse { Errors = errors } );
        }

        var response = await commandService.CreateEmployee( request );

        return Ok( response );
    }

    [HttpPut("update-by/{employeeId}")]
    [ProducesResponseType(typeof(EmployeeResponse), 200)]
    [ProducesResponseType(typeof(FailedOperationResult), 404)]
    [ProducesResponseType(typeof(FailedOperationResult), 400)]
    public async Task<IActionResult> UpdateEmployee( Guid employeeId, EmployeeRequest request )
    {
        var response = await commandService.UpdatedEmployee( employeeId, request );

        return Ok( response );
    }

    [HttpDelete("delete-by/{employeeId}")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(FailedOperationResult), 404)]
    [ProducesResponseType(typeof(FailedOperationResult), 400)]
    public async Task<IActionResult> DeleteEmployee( Guid employeeId )
    {
        var response = await commandService.DeleteEmployee( employeeId );

        return Ok( response );

    }
}
