using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Dto.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly IServiceCompany _serviceCompany;
        private readonly IValidator<CompanyBase> _validator;

        public CompanyController(IServiceCompany serviceCompany, IValidator<CompanyBase> validator)
        {
            _serviceCompany = serviceCompany;
            _validator = validator;
        }

        [HttpGet("list-company")]
        public async Task<IActionResult> Companies()
        {
            var response = await _serviceCompany.GetCompanies();
            return Ok(response);
        }

        [HttpGet("get-company-by/{companyId}")]
        public async Task<IActionResult> Company(Guid companyId)
        {
            var response = await _serviceCompany.GetCompany(companyId);
            return Ok(response);
        }

        [HttpPost("add-company")]
        public async Task<IActionResult> Create(CompanyBase empresabase)
        {
            var Validacion = _validator.Validate(empresabase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new CompanyResponse { Errors = errors });
            }
            else
            {
                var response = await _serviceCompany.CreateCompany(empresabase);
                return Ok(response);
            }
        }

        [HttpPut("update-company-by/{companyId}")]
        public async Task<IActionResult> UpdateCompany(Guid companyId, CompanyBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new CompanyResponse { Errors = errors });
            }
            else
            {
                var response = await _serviceCompany.UpdateCompany(companyId, actualizar);
                return Ok(response);
            }
        }

        [HttpDelete("delete/{companyId}")]
        public async Task<IActionResult> Eliminar(Guid companyId)
        {
            var response = await _serviceCompany.DeleteCompany(companyId);
            return Ok(response);

        }
    }
}
