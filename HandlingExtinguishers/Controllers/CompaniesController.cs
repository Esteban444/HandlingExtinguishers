using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models.Pagination;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceCompany _serviceCompany;

        public CompaniesController(IServiceCompany serviceCompany)
        {
            _serviceCompany = serviceCompany;
        }

        [HttpGet("search-company-enable")]
        [ProducesResponseType(typeof(FilterCompanyResponseDto), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> Companies([FromQuery] QueryParameter filter)
        {
            var response = await _serviceCompany.GetCompanies(filter);
            return Ok(response);
        }

        [HttpGet("search-company-disabled")]
        [ProducesResponseType(typeof(FilterCompanyResponseDto), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> CompaniesDasabled([FromQuery] QueryParameter filter)
        {
            var response = await _serviceCompany.GetCompaniesDisabled(filter);
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
        public async Task<IActionResult> Create(CompanyRequestDto empresabase)
        {
            var response = await _serviceCompany.CreateCompany(empresabase);
            return Ok(response);
        }

        [HttpPatch("update-company-by/{companyId}")]
        [ProducesResponseType(typeof(CompanyResponseDto), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> UpdateCompany(Guid companyId, PatchCompanyRequestDto actualizar)
        {
            var response = await _serviceCompany.UpdateFieldsCompany(companyId, actualizar);
            return Ok(response);
        }

        [HttpDelete("delete-company-permanent-by/{companyId}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> Eliminar (Guid companyId)
        {
            var response = await _serviceCompany.DeleteCompany(companyId);
            return Ok(response);

        }
    }
}
