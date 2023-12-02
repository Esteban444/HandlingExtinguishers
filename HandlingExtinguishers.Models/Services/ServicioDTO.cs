using HandlingExtinguisher.Dto.Clients;
using HandlingExtinguishers.Models.Employees;

namespace ManagementFireEstinguisher.Dto.Services
{
    public class ServicioDTO : ServicioBase
    {
        public int IdServicios { get; set; }

        public ClientDto? Cliente { get; set; }
        public EmployeeResponseDto? Empleado { get; set; }
    }
}
