using HandlingExtinguisher.Dto.Clients;
using HandlingExtinguisher.Dto.Employees;

namespace ManagementFireEstinguisher.Dto.Services
{
    public class ServicioDTO : ServicioBase
    {
        public int IdServicios { get; set; }

        public ClientDto? Cliente { get; set; }
        public EmployeeDto? Empleado { get; set; }
    }
}
