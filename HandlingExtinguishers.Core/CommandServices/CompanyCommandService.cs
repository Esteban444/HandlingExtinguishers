namespace HandlingExtinguishers.Core.CommandServices;

#region Usings
using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.CommandServices;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Core.Exceptions;
using HandlingExtinguishers.Core.Localization;
using HandlingExtinguishers.Models.Company;
using HandlingExtinguishers.Models.Models;
using Microsoft.EntityFrameworkCore;
#endregion

public class CompanyCommandService( ICompanyRepository repository,
                                    IEmployeeRepository employeeRepository,
                                    IMapper mapper ) : ICompanyCommandService
{
    public async Task<CompanyResponse> CreateCompany( CompanyRequest request )
    {
        var result = await repository.FindByAsNoTracking( company => company.Nit == request.Nit ).AnyAsync();

        if ( result )throw new HandlingExceptions(HandlingExtinguisherResources.DuplicatedCompany);

        var company = Company.Create( request.Name!, request.Address,request.Phone, request.Email, request.Nit! );

        await repository.Add( company );

        return mapper.Map<CompanyResponse>( company );
    }

    public async Task<CompanyResponse> UpdateCompany( Guid companyId, UpdateCompanyRequest request )
    {
        var company = await repository.FindBy( company => company.CompanyId == companyId ).FirstOrDefaultAsync()
                                              ?? throw new HandlingExceptions(HandlingExtinguisherResources.CompanyNotFound);

        company.Update( request.Name, 
                        request.Address, 
                        request.Phone,
                        request.Email, 
                        request.Nit, 
                        request.Active );

        await repository.Patch( company );

        return mapper.Map<CompanyResponse>( company );
    }

    public async Task<bool> DeleteCompany( Guid companyId )
    {
        var company = await repository.FindBy( company => company.CompanyId == companyId ).FirstOrDefaultAsync()
                                              ?? throw new HandlingExceptions(HandlingExtinguisherResources.CompanyNotFound);

        var employees = await employeeRepository.FindBy( employee => employee.CompanyId == companyId ).ToListAsync();

        if ( employees.Any() )
            await employeeRepository.DeleteRange( employees );

        await repository.Delete( company );

        return true;
    }
}
