using HandlingExtinguishers.Models.Company;

namespace HandlingExtinguishers.Models.Employees
{
    public class EmployeeResponseDto
    {
        public Guid? IdCompany { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public CompanyResponseDto? Company { get; set; }
    }
}
