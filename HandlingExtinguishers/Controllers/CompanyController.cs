namespace HandlingExtinguishers.Controllers;

using FluentValidation;

#region Usings
using HandlingExtinguishers.Contracts.Interfaces.CommandServices;
using HandlingExtinguishers.Contracts.Interfaces.QueryServices;
using HandlingExtinguishers.Models;
using HandlingExtinguishers.Models.Company;
using HandlingExtinguishers.Models.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endregion

[ApiController]
[Route("api/company")]
[Authorize]
public class CompanyController( ICompanyQueryService queryService,
                                ICompanyCommandService commandService,
                                IValidator<CompanyRequest> validator ) : ControllerBase
{
    public IValidator<CompanyRequest> Validator = validator;


    [HttpGet("search-company-enable")]
    public async Task<IActionResult> SearchCompanies( [FromQuery] QueryParameter filter ) =>
        Ok( await queryService.SearchCompanies( filter ) );

    [HttpGet("search-company-disabled")]
    public async Task<IActionResult> SearchCompaniesDisabled( [FromQuery] QueryParameter filter ) =>
        Ok( await queryService.SearchCompaniesDisabled( filter ) );

    [HttpGet("search-by/{companyId}")]
    public async Task<IActionResult> SearchCompany( Guid companyId ) =>
        Ok( await queryService.SearchCompany( companyId ) );

    [HttpPost("create")]
    public async Task<IActionResult> CreateCompany( CompanyRequest company)
    {
        var validationResult = await Validator.ValidateAsync( company );
        if ( !validationResult.IsValid )
        {
            var errors = validationResult.Errors.Select( error => error.ErrorMessage ).ToList();

            return BadRequest(new ErrorResponse { Errors = errors });
        }

        return Ok( await commandService.CreateCompany( company ) );
    }

    [HttpPatch("update-by/{companyId}")]
    public async Task<IActionResult> UpdateCompany( Guid companyId, UpdateCompanyRequest company ) =>
        Ok( await commandService.UpdateCompany( companyId, company ) );

    [HttpDelete("delete-by/{companyId}")]
    public async Task<IActionResult> DeletedCompany( Guid companyId ) =>
        Ok( await commandService.DeleteCompany( companyId ) );
}