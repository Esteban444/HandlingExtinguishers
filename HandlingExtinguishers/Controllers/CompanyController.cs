using FluentValidation;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Dto.Company;
using HandlingExtinguishers.Dto.Pagination;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Company;
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

        public CompanyController(IServiceCompany serviceCompany)
        {
            _serviceCompany = serviceCompany;
        }

        [HttpGet("search-company")]
        [ProducesResponseType(typeof(FilterCompanyResponseDto), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> Companies([FromQuery] QueryParameter filter)
        {
            var response = await _serviceCompany.GetCompanies(filter);
            return Ok(response);
        }

        [HttpGet("search-company-by/{companyId}")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> Company(Guid companyId)
        {
            var response = await _serviceCompany.GetCompany(companyId);
            return Ok(response);
        }

        [HttpPost("add-company")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> Create(CompanyBase empresabase)
        {
           var response = await _serviceCompany.CreateCompany(empresabase);
           return Ok(response);
        }

        [HttpPut("update-company-by/{companyId}")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> UpdateCompany(Guid companyId, CompanyBase actualizar)
        {
            var response = await _serviceCompany.UpdateCompany(companyId, actualizar);
            return Ok(response);
        }

        [HttpDelete("delete/{companyId}")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> Eliminar(Guid companyId)
        {
            var response = await _serviceCompany.DeleteCompany(companyId);
            return Ok(response);

        }
    }
}
