using AutoMapper;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Models;
using HandlingExtinguishers.Models.Pagination;
using HandlingFireExtinguisher.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplicationFacturas.Helpers;

namespace HandlingExtinguishers.Core.Services
{
    public class ServiceEmployee : IServiceEmployee
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryEmployee _repositoryEmployee;

        public ServiceEmployee(IRepositoryEmployee repositoryEmployee, IMapper mapper)
        {
            this._repositoryEmployee = repositoryEmployee;
            this._mapper = mapper;
        }

        public async Task<FilterEmployeeResponseDto> SearchEmployees(QueryParameter filter)
        {
            try
            {
                var response = new FilterEmployeeResponseDto();

                var result = _repositoryEmployee.FindByAsNoTracking(x => x.Active);

                if (filter.OrderBy == "Id") filter.OrderBy = "Name";

                if (!string.IsNullOrEmpty(filter.Search))
                {
                    result = result.Where(x => x.FirstName!.ToLower().Contains(filter.Search) || x.LastName!.ToLower().Contains(filter.Search));
                }
                var employees = await result.PaginateAsync(filter);
                var preResponse = _mapper.Map<List<EmployeeBaseResponseDto>>(employees.Resource);

                response.Employees = PaginationHelper.CreatePagedReponse<EmployeeBaseResponseDto>(preResponse, filter, employees.TotalRecords);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmployeeResponseDto> SearchEmployeeById(Guid id)
        {
            try
            {
                var result = await _repositoryEmployee.FindBy(x => x.Id == id).Include(x => x.Company).FirstOrDefaultAsync();
                if (result != null)
                {
                    return _mapper.Map<EmployeeResponseDto>(result);
                }
                else
                {
                    throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El empleado que solicita no existe en la base de datos" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmployeeBaseResponseDto> AddEmployee(EmployeeRequestDto request)
        {
            try
            {
                var employee = _mapper.Map<Employee>(request);
                employee.Active = true;

                await _repositoryEmployee.Add(employee);
                var response = _mapper.Map<EmployeeBaseResponseDto>(request);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmployeeResponseDto> UpdatedFieldEmployee(Guid employeeId, PatchEmployeeRequestDto request)
        {
            try
            {
                var result = await _repositoryEmployee.FindBy(x => x.Id == employeeId).FirstOrDefaultAsync();
                if (result != null)
                {
                    var properties = new UpdateMapperProperties<Employee, PatchEmployeeRequestDto>();
                    var resultToUpdate = await properties.MapperUpdate(result!, request);

                    if (request.Active.HasValue)
                    {
                        resultToUpdate.Active = request.Active.Value;
                    }
                    else
                    {
                        resultToUpdate.Active = result.Active;
                    }

                    await _repositoryEmployee.Patch(resultToUpdate);
                    var response = _mapper.Map<EmployeeResponseDto>(resultToUpdate);
                    return response;
                }
                else
                {
                    throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "La empleado que desea actualizar no existe en la base de datos" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteEmployee(Guid employeeId)
        {

            var result = await _repositoryEmployee.FindBy(e => e.Id == employeeId).FirstOrDefaultAsync();
            if (result != null)
            {
                await _repositoryEmployee.Delete(result);
                return true;
            }
            else
            {
                throw new HandlingExceptions(HttpStatusCode.NotFound, new { Mensaje = "El empleado no existe en la base de datos" });
            }
        }
    }
}
