namespace HandlingExtinguishers.Core.Services;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Models.Pagination;
using HandlingExtinguishers.Models.Company;
using HandlingExtinguishers.Models.Models;
using HandlingFireExtinguisher.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using WebApplicationFacturas.Helpers;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
#endregion

public class ServiceCompany( IRepositoryCompany repositoryCompany, IMapper mapper, 
                             IRepositoryEmployee repositoryEmployee ) : ICompanyService
{
    private readonly IRepositoryCompany repositoryCompany = repositoryCompany;
    private readonly IRepositoryEmployee repositoryEmployee = repositoryEmployee;
    private readonly IMapper mapper = mapper;

    public async Task<FilterCompanyResponseDto> SearchCompanies( QueryParameter filter )
    {
        try
        {
            var response = new FilterCompanyResponseDto();

            var search = repositoryCompany.FindByAsNoTracking( company => company.Active );

            if ( filter.OrderBy == "Id" ) filter.OrderBy = "Name";

            if ( !string.IsNullOrEmpty( filter.Search ) )
            {
                search = search.Where( company => company.Name!.ToLower().Contains(filter.Search));
            }

            var pagegResult = await search.PaginateAsync( filter ); // aca se hacen los includes

            var result = mapper.Map<List<CompanyResponseDto>>( pagegResult.Resource );

            response.Companies = PaginationHelper.CreatePagedReponse<CompanyResponseDto>( result, filter, pagegResult.TotalRecords );

            return response;
        }
        catch ( Exception )
        {
            throw;
        }
    }

    public async Task<FilterCompanyResponseDto> SearchCompaniesDisabled( QueryParameter filter )
    {
        try
        {
            var response = new FilterCompanyResponseDto();

            var search = repositoryCompany.FindByAsNoTracking( company => company.Active == false);

            if ( filter.OrderBy == "Id" ) filter.OrderBy = "Name";

            if ( !string.IsNullOrEmpty( filter.Search ) )
            {
                search = search.Where( company => company.Name!.ToLower().Contains( filter.Search ) );
            }

            var pagedResult = await search.PaginateAsync(filter); // aca se hacen los includes

            var result = mapper.Map<List<CompanyResponseDto>>( pagedResult.Resource );

            response.Companies = PaginationHelper.CreatePagedReponse<CompanyResponseDto>( result, filter, pagedResult.TotalRecords );

            return response;
        }
        catch ( Exception )
        {
            throw;
        }
    }

    public async Task<CompanyResponseDto> SearchCompany( Guid companyId )
    {
        var result = await repositoryCompany.FindByAsNoTracking( company => company.Active && company.Id == companyId ).FirstOrDefaultAsync();

        if ( result is not null )
        {
            return mapper.Map<CompanyResponseDto>( result );
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.CompanyNotFound );
        }
    }


    public async Task<CompanyRequestDto> CreateCompany(CompanyRequestDto company )
    {
        try
        {
            var search = await repositoryCompany.FindByAsNoTracking( company => company.Nit == company.Nit ).FirstOrDefaultAsync();

            if ( search is not null ) throw new HandlingExceptions( HandlingExtinguisherResources.DuplicatedCompany );

            var result = mapper.Map<Company>( company );

            result.Active = true;

            await repositoryCompany.Add( result );

            var response = mapper.Map<CompanyRequestDto>( result );

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CompanyRequestDto> UpdateCompany(Guid companyId, PatchCompanyRequestDto request)
    {
        try
        {
            var search = await repositoryCompany.FindBy(x => x.Id == companyId).FirstOrDefaultAsync();

            if ( search is not null )
            {
                var properties = new UpdateMapperProperties<Company, PatchCompanyRequestDto>();

                var result = await properties.MapperUpdate( search!, request );

                if ( request.Active.HasValue )
                {
                    result.Active = request.Active.Value;
                }
                else
                {
                    result.Active = search.Active;
                }

                await repositoryCompany.Patch( result );

                var response = mapper.Map<CompanyRequestDto>( result );

                return response;
            }
            else
            {
                throw new HandlingExceptions( HandlingExtinguisherResources.CompanyNotFound );
            }
        }
        catch ( Exception )
        {
            throw;
        }
    }

    public async Task<bool> DeleteCompany( Guid companyId )
    {
        var company = await repositoryCompany.FindBy( company => company.Id == companyId ).FirstOrDefaultAsync();

        if ( company is not null )
        {
            try
            {
                var employees = await repositoryEmployee.FindBy( employee => employee.CompanyId == companyId ).ToListAsync();

                if ( employees is not null )
                {
                    await repositoryEmployee.DeleteRange( employees );
                }

                await repositoryCompany.Delete( company );

                var response = true;

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        else
        {
            throw new HandlingExceptions( HandlingExtinguisherResources.CompanyNotFound );
        }
    }

}
