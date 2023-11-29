namespace HandlingExtinguishers.Dto.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid? IdCompany { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public Companies? Company { get; set; }
        public ICollection<Service>? Services { get; set; }
    }
}
