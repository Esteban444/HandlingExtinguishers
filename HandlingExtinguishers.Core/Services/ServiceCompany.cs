﻿using AutoMapper;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Dto.Company;
using HandlingExtinguishers.Dto.Models;
using HandlingExtinguishers.Dto.Pagination;
using HandlingExtinguishers.Models.Company;
using HandlingFireExtinguisher.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HandlingEstinguishers.Core.Servicios
{
    public class ServiceCompany : IServiceCompany
    {
        private readonly IRepositoryCompany _repositoryCompany;
        private readonly IMapper _mapper;

        public ServiceCompany(IRepositoryCompany repositoryCompany, IMapper mapper)
        {
            _repositoryCompany = repositoryCompany;
            _mapper = mapper;
        }

        public async Task<FilterCompanyResponseDto> GetCompanies(QueryParameter filter)
        {
            try
            {
                var response = new FilterCompanyResponseDto();

                var result =  _repositoryCompany.GetAll();

                if(filter.OrderBy  ==  "Id") filter.OrderBy = "Name";

                if (!string.IsNullOrEmpty(filter.Search))
                {
                    result = result.Where(x => x.Name!.ToLower().Contains(filter.Search));
                }
                var companies = await  result.PaginateAsync(filter); // aca se hacen los includes
                var preResponse = _mapper.Map<List<CompanyResponseDto>>(companies.Resource);

                response.Companies = PaginationHelper.CreatePagedReponse<CompanyResponseDto>(preResponse,filter, companies.TotalRecords);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CompanyResponseDto> GetCompany(Guid companyId)
        {
            var result = await _repositoryCompany.FindByAsNoTracking(x => x.Id == companyId).FirstOrDefaultAsync();
            if (result != null)
            {
                return _mapper.Map<CompanyResponseDto>(result);
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "La empresa que solicita no existe en la base de datos" });
            }
        }


        public async Task<CompanyBase> CreateCompany(CompanyBase company)
        {
            var result = _mapper.Map<Companies>(company);
            await _repositoryCompany.Add(result);
            var response = _mapper.Map<CompanyBase>(result);
            return response;
        }

        public async Task<CompanyBase> UpdateCompany(Guid companyId, CompanyBase company)
        {
            var result = await _repositoryCompany.FindBy(e => e.Id == companyId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.Name = company.Name;
                result.Address = company.Address;
                result.Phone = company.Phone;
                result.Email = company.Email;
                result.Nit = company.Nit;

                await _repositoryCompany.Update(result);
                var response = _mapper.Map<CompanyBase>(result);
                return response;
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "La empresa que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<CompanyResponseDto> DeleteCompany(Guid companyId)
        {
            var company = await _repositoryCompany.FindBy(e => e.Id == companyId).FirstOrDefaultAsync();
            if (company != null)
            {
                try
                {
                    await _repositoryCompany.Delete(company);
                    var response = _mapper.Map<CompanyResponseDto>(company);
                    return response;
                }
                catch (Exception)
                {
                    throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "La empresa tiene relacion con empleados no se puede borrar" });
                }
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "La empresa no existe en la base de datos" });
            }
        }
    }
}
