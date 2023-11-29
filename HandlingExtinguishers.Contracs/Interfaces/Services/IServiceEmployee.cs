using HandlingExtinguisher.Dto.Employees;
using ManejoExtintores.Core.Filtros_Busqueda;

namespace HandlingExtinguisher.Contracts.Interfaces.Services
{
    public interface IServiceEmployee
    {
        Task<IEnumerable<EmployeeDto>> ConsultaEmpleados(FiltroEmpleados filtros);
        Task<EmployeeDto> ConsultaEmpleadoPorId(Guid id);
        Task<EmployeeBase> CrearEmpleado(EmployeeBase empleado);
        Task<EmployeeBase> ActualizarEmpleado(Guid id, EmployeeBase empleado);
        Task<EmployeeDto> EliminarEmpleado(Guid id);
    }
}
