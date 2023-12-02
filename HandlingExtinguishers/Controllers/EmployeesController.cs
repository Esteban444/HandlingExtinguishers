using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceEmployee _serviceEmployee;

        public EmployeesController(IServiceEmployee serviceEmployee)
        {
            _serviceEmployee = serviceEmployee;
        }

        [HttpGet("search-employees")]
        [ProducesResponseType(typeof(FilterEmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> Employees([FromQuery] QueryParameter filter)
        {
            var response = await _serviceEmployee.SearchEmployees(filter);
            return Ok(response);
        }

        [HttpGet("search-employee-by/{employeeId}")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> EmployeeById(Guid employeeId)
        {
            var response = await _serviceEmployee.SearchEmployeeById(employeeId);
            return Ok(response);
        }

        [HttpPost("add-employee")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> AddEnployee(EmployeeRequestDto empleadob)
        {
            var response = await _serviceEmployee.AddEmployee(empleadob);
            return Ok(response);
        }

        [HttpPut("update-employee-by/{employeeId}")]
        [ProducesResponseType(typeof(EmployeeResponseDto), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> UpdateEmployee(Guid employeeId, PatchEmployeeRequestDto request)
        {
            var response = await _serviceEmployee.UpdatedFieldEmployee(employeeId, request);
            return Ok(response);
        }

        [HttpDelete("delete-employee-by/{employeeId}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            var response = await _serviceEmployee.DeleteEmployee(employeeId);
            return Ok(response);

        }
    }
}
