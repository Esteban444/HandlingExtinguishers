using FluentValidation;
using HandlingExtinguisher.Dto.Employees;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using ManejoExtintores.Core.Filtros_Busqueda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
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
            var response = await _serviceEmployee.ConsultaEmpleados(filtros);
            return Ok(response);
        }

        [HttpGet("employee-by/{idEmployee}")]
        public async Task<IActionResult> EmployeeById(Guid idEmployee)
        {
            var response = await _serviceEmployee.ConsultaEmpleadoPorId(idEmployee);
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
                var response = await _serviceEmployee.CrearEmpleado(empleadob);
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
                var response = await _serviceEmployee.ActualizarEmpleado(idEmployee, actualizar);
                return Ok(response);
            }
        }

        [HttpDelete("delete/{idEmployee}")]
        public async Task<IActionResult> EliminarEmpleado(Guid idEmployee)
        {
            var response = await _serviceEmployee.EliminarEmpleado(idEmployee);
            return Ok(response);

        }
    }
}
