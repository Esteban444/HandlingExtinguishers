using HandlingExtinguishers.Dto.Company;

namespace HandlingExtinguisher.Dto.Employees
{
    public class EmployeeDto : EmployeeBase
    {
        public Guid IdEmpleados { get; set; }
        public CompanyResponseDto? Empresa { get; set; }

    }
}
