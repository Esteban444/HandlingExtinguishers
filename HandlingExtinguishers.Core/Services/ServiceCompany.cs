using AutoMapper;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models.Pagination;
using HandlingExtinguishers.Models.Company;
using HandlingExtinguishers.Models.Models;
using HandlingFireExtinguisher.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplicationFacturas.Helpers;

namespace HandlingEstinguishers.Core.Servicios
{
    public class ServiceCompany : IServiceCompany
    {
        private readonly IRepositoryCompany _repositoryCompany;
        private readonly IRepositoryEmployee _repositoryEmployee;
        private readonly IMapper _mapper;

        public ServiceCompany(IRepositoryCompany repositoryCompany, IMapper mapper, IRepositoryEmployee repositoryEmployee)
        {
            this._repositoryCompany = repositoryCompany;
            this._mapper = mapper;
            this._repositoryEmployee = repositoryEmployee;
        }

        public async Task<FilterCompanyResponseDto> GetCompanies(QueryParameter filter)
        {
            try
            {
                var response = new FilterCompanyResponseDto();

                var result = _repositoryCompany.FindByAsNoTracking(x => x.Active);

                if (filter.OrderBy == "Id") filter.OrderBy = "Name";

                if (!string.IsNullOrEmpty(filter.Search))
                {
                    result = result.Where(x => x.Name!.ToLower().Contains(filter.Search));
                }
                var companies = await result.PaginateAsync(filter); // aca se hacen los includes
                var preResponse = _mapper.Map<List<CompanyResponseDto>>(companies.Resource);

                response.Companies = PaginationHelper.CreatePagedReponse<CompanyResponseDto>(preResponse, filter, companies.TotalRecords);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FilterCompanyResponseDto> GetCompaniesDisabled(QueryParameter filter)
        {
            try
            {
                var response = new FilterCompanyResponseDto();

                var result = _repositoryCompany.FindByAsNoTracking(x => x.Active == false);

                if (filter.OrderBy == "Id") filter.OrderBy = "Name";

                if (!string.IsNullOrEmpty(filter.Search))
                {
                    result = result.Where(x => x.Name!.ToLower().Contains(filter.Search));
                }
                var companies = await result.PaginateAsync(filter); // aca se hacen los includes
                var preResponse = _mapper.Map<List<CompanyResponseDto>>(companies.Resource);

                response.Companies = PaginationHelper.CreatePagedReponse<CompanyResponseDto>(preResponse, filter, companies.TotalRecords);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CompanyResponseDto> GetCompany(Guid companyId)
        {
            var result = await _repositoryCompany.FindByAsNoTracking(x => x.Active && x.Id == companyId).FirstOrDefaultAsync();
            if (result != null)
            {
                return _mapper.Map<CompanyResponseDto>(result);
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "La empresa que solicita no existe en la base de datos" });
            }
        }


        public async Task<CompanyRequestDto> CreateCompany(CompanyRequestDto company)
        {
            try
            {
                var result = await _repositoryCompany.FindByAsNoTracking(e => e.Nit == company.Nit).FirstOrDefaultAsync();
                if (result != null) throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "Ya existe una empresa con el mismo nit,Por favor actualizala." });
                var newCompany = _mapper.Map<Company>(company);
                newCompany.Active = true;
                await _repositoryCompany.Add(newCompany);
                var response = _mapper.Map<CompanyRequestDto>(newCompany);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CompanyRequestDto> UpdateFieldsCompany(Guid companyId, PatchCompanyRequestDto request)
        {
            try
            {
                var result = await _repositoryCompany.FindBy(x => x.Id == companyId).FirstOrDefaultAsync();
                if (result != null)
                {
                    var properties = new UpdateMapperProperties<Company, PatchCompanyRequestDto>();
                    var resultToUpdate = await properties.MapperUpdate(result!, request);

                    if (request.Active.HasValue)
                    {
                        resultToUpdate.Active = request.Active.Value;
                    }
                    else
                    {
                        resultToUpdate.Active = result.Active;
                    }

                    await _repositoryCompany.Patch(resultToUpdate);
                    var response = _mapper.Map<CompanyRequestDto>(resultToUpdate);
                    return response;
                }
                else
                {
                    throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "La empresa que desea actualizar no existe en la base de datos" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCompany(Guid companyId)
        {
            var company = await _repositoryCompany.FindBy(x => x.Id == companyId).FirstOrDefaultAsync();
            if (company != null)
            {
                try
                {
                    var employees = await _repositoryEmployee.FindBy(x => x.CompanyId == companyId).ToListAsync();
                    if (employees != null)
                    {
                        await _repositoryEmployee.DeleteRange(employees);
                    }
                    await _repositoryCompany.Delete(company);
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
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "La empresa no existe en la base de datos" });
            }
        }
    
    }
}
