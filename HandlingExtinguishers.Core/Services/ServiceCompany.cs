using AutoMapper;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Dto.Company;
using HandlingExtinguishers.Dto.Models;
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

        public async Task<IEnumerable<CompanyDto>> GetCompanies()
        {
            try
            {
                var result = await _repositoryCompany.GetAll().ToListAsync();
                var response = _mapper.Map<IEnumerable<CompanyDto>>(result);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CompanyDto> GetCompany(Guid companyId)
        {
            var result = await _repositoryCompany.FindByAsNoTracking(x => x.Id == companyId).FirstOrDefaultAsync();
            if (result != null)
            {
                return _mapper.Map<CompanyDto>(result);
            }
            else
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "La empresa que solicita no existe en la base de datos" });
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
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "La empresa que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<CompanyDto> DeleteCompany(Guid companyId)
        {
            var company = await _repositoryCompany.FindBy(e => e.Id == companyId).FirstOrDefaultAsync();
            if (company != null)
            {
                try
                {
                    await _repositoryCompany.Delete(company);
                    var response = _mapper.Map<CompanyDto>(company);
                    return response;
                }
                catch (Exception)
                {
                    throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "La empresa tiene relacion con empleados no se puede borrar" });
                }
            }
            else
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "La empresa no existe en la base de datos" });
            }
        }
    }
}
