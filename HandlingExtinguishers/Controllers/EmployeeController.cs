namespace HandlingExtinguishers.Controllers;

using HandlingExtinguishers.Contracts.Interfaces;

#region Usings
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endregion


[Route("api/employee")]
[ApiController]
[Authorize]
public class EmployeeController( IEmployeeService serviceEmployee ) : ControllerBase
{
    private readonly IEmployeeService serviceEmployee = serviceEmployee;

    [HttpGet("search")]
    [ProducesResponseType(typeof(FilterEmployeeResponse), 200)]
    [ProducesResponseType(typeof(FailedOperationResult), 404)]
    [ProducesResponseType(typeof(FailedOperationResult), 400)]
    public async Task<IActionResult> Employees([FromQuery] QueryParameter filter)
    {
        var response = await serviceEmployee.SearchEmployees(filter);
        return Ok(response);
    }

    [HttpGet("search-by/{employeeId}")]
    [ProducesResponseType(typeof(EmployeeResponse), 200)]
    [ProducesResponseType(typeof(FailedOperationResult), 404)]
    [ProducesResponseType(typeof(FailedOperationResult), 400)]
    public async Task<IActionResult> EmployeeById( Guid employeeId )
    {
        var response = await serviceEmployee.SearchEmployeeById( employeeId );

        return Ok( response );
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(EmployeeResponse), 200)]
    [ProducesResponseType(typeof(FailedOperationResult), 404)]
    [ProducesResponseType(typeof(FailedOperationResult), 400)]
    public async Task<IActionResult> CreateEmployee( EmployeeRequest request )
    {
        var response = await serviceEmployee.CreateEmployee( request );

        return Ok( response );
    }

    [HttpPut("update-by/{employeeId}")]
    [ProducesResponseType(typeof(EmployeeResponse), 200)]
    [ProducesResponseType(typeof(FailedOperationResult), 404)]
    [ProducesResponseType(typeof(FailedOperationResult), 400)]
    public async Task<IActionResult> UpdateEmployee( Guid employeeId, EmployeeRequest request )
    {
        var response = await serviceEmployee.UpdatedEmployee( employeeId, request );

        return Ok( response );
    }

    [HttpDelete("delete-by/{employeeId}")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(FailedOperationResult), 404)]
    [ProducesResponseType(typeof(FailedOperationResult), 400)]
    public async Task<IActionResult> DeleteEmployee( Guid employeeId )
    {
        var response = await serviceEmployee.DeleteEmployee( employeeId );

        return Ok( response );

    }
}
