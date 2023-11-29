namespace HandlingExtinguishers.Dto.Models
{
    public class Companies
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Nit { get; set; }

        public ICollection<Employee>? Employee { get; set; }
    }
}
