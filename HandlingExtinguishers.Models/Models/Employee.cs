namespace HandlingExtinguishers.Models.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public Company? Company { get; set; }
        public ICollection<Service>? Services { get; set; }
    }
}
