using FluentValidation;
using HandlingExtinguisher.Dto.Employees;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Dto;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceEmployee _serviceEmployee;
        private readonly IValidator<EmployeeBase> _validator;

        public EmployeeController(IServiceEmployee serviceEmployee, IValidator<EmployeeBase> validator)
        {
            _serviceEmployee = serviceEmployee;
            _validator = validator;
        }

        [HttpGet("employees")]
        public async Task<IActionResult> Employees([FromQuery] FiltroEmpleados filtros)
        {
            var employees = await _serviceEmployee.ConsultaEmpleados(filtros);
            var response = new OperationResult<IEnumerable<EmployeeDto>>(employees);
            return Ok(response);
        }

        [HttpGet("employee-by/{idEmployee}")]
        public async Task<IActionResult> EmployeeById(Guid idEmployee)
        {
            var empleado = await _serviceEmployee.ConsultaEmpleadoPorId(idEmployee);
            var response = new OperationResult<EmployeeDto>(empleado);
            return Ok(response);
        }

        [HttpPost("employee")]
        public async Task<IActionResult> AddEnployee(EmployeeBase empleadob)
        {
            var Validacion = _validator.Validate(empleadob);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new EmployeeResponseDto { Errors = errors });
            }
            else
            {
                await _serviceEmployee.CrearEmpleado(empleadob);
                var response = new OperationResult<EmployeeBase>(empleadob);
                return Ok(response);
            }
        }

        [HttpPut("update/{idEmployee}")]
        public async Task<IActionResult> UpdateEmployee(Guid idEmployee, EmployeeBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new EmployeeResponseDto { Errors = errors });
            }
            else
            {
                var result = await _serviceEmployee.ActualizarEmpleado(idEmployee, actualizar);
                var response = new OperationResult<EmployeeBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("delete/{idEmployee}")]
        public async Task<IActionResult> EliminarEmpleado(Guid idEmployee)
        {
            var result = await _serviceEmployee.EliminarEmpleado(idEmployee);
            var response = new OperationResult<EmployeeDto>(result);
            return Ok(response);

        }
    }
}
