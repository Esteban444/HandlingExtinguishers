using AutoMapper;
using HandlingExtinguisher.Core.Exceptions;
using HandlingExtinguisher.Dto.Employees;
using HandlingExtinguishers.Contracts.Interfaces.Repositories;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.Dto.Models;
using ManejoExtintores.Core.Filtros_Busqueda;
using System.Data.Entity;
using System.Net;

namespace HandlingExtinguishers.Core.Services
{
    public class ServiceEmployee : IServiceEmployee
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryEmployee _repositorio;

        public ServiceEmployee(IRepositoryEmployee repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> ConsultaEmpleados(FiltroEmpleados filtros)
        {
            var empleado = await _repositorio.GetAll().ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(empleado);
        }

        public async Task<EmployeeDto> ConsultaEmpleadoPorId(Guid id)
        {
            var empleado = await _repositorio.FindBy(x => x.Id == id).FirstOrDefaultAsync();
            if (empleado != null)
            {
                return _mapper.Map<EmployeeDto>(empleado);
            }
            else
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El empleado que solicita no existe en la base de datos" });
            }
        }

        public async Task<EmployeeBase> CrearEmpleado(EmployeeBase empleadob)
        {
            var empleado = _mapper.Map<Employee>(empleadob);
            await _repositorio.Add(empleado);
            empleadob = _mapper.Map<EmployeeBase>(empleado);
            return empleadob;
        }

        public async Task<EmployeeBase> ActualizarEmpleado(Guid id, EmployeeBase empleadod)
        {
            var result = await _repositorio.FindBy(e => e.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IdCompany = empleadod.IdCompany;
                result.Address = empleadod.Nombre;
                result.LastName = empleadod.Apellido;
                result.Address = empleadod.Direccion;
                result.Phone = empleadod.Telefono;
                result.Email = empleadod.Email;

                await _repositorio.Update(result);
                var response = _mapper.Map<EmployeeBase>(result);
                return response;
            }
            else
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El empleado que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<EmployeeDto> EliminarEmpleado(Guid id)
        {
            var empleadobd = await _repositorio.FindBy(e => e.Id == id).FirstOrDefaultAsync();
            if (empleadobd != null)
            {
                await _repositorio.Delete(empleadobd);
                var empleadoE = _mapper.Map<EmployeeDto>(empleadobd);
                return empleadoE;
            }
            else
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El empleado no existe en la base de datos" });
            }
        }
    }
}
