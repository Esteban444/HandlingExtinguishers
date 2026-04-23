using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models.Pagination;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.Controllers
{
    [ApiController]
    [Route("api/company")]
    [Authorize]
    public class CompanyController( ICompanyService serviceCompany ) : ControllerBase
    {
        private readonly ICompanyService serviceCompany = serviceCompany;

        [HttpGet("search-company-enable")]
        [ProducesResponseType(typeof(FilterCompanyResponse), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> SearchCompanies( [FromQuery] QueryParameter filter )
        {
            var response = await serviceCompany.SearchCompanies( filter );

            return Ok( response );
        }

        [HttpGet("search-company-disabled")]
        [ProducesResponseType(typeof(FilterCompanyResponse), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> SearchCompaniesDisabled( [FromQuery] QueryParameter filter )
        {
            var response = await serviceCompany.SearchCompaniesDisabled( filter );

            return Ok( response );
        }

        [HttpGet("search-by/{companyId}")]
        [ProducesResponseType(typeof(CompanyResponse), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> SearchCompany( Guid companyId )
        {
            var response = await serviceCompany.SearchCompany( companyId );

            return Ok( response);
        }

        [HttpPost("Create")]
        [ProducesResponseType(typeof(CompanyResponse), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> CreateCompany( CompanyRequest company )
        {
            var response = await serviceCompany.CreateCompany( company );

            return Ok( response );
        }

        [HttpPatch("update-by/{companyId}")]
        [ProducesResponseType(typeof(CompanyResponse), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> UpdateCompany( Guid companyId, PatchCompanyRequest company )
        {
            var response = await serviceCompany.UpdateCompany( companyId, company );

            return Ok( response );
        }

        [HttpDelete("delete-by/{companyId}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(FailedOperationResult), 404)]
        [ProducesResponseType(typeof(FailedOperationResult), 400)]
        public async Task<IActionResult> DeletedCompany ( Guid companyId )
        {
            var response = await serviceCompany.DeleteCompany( companyId );

            return Ok( response );

        }
    }
}
