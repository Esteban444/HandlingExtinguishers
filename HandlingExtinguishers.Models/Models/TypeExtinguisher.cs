namespace HandlingExtinguishers.Models.Models
{
    public class TypeExtinguisher
    {
        public Guid Id { get; set; }
        public string? TYpeExtinguisher { get; set; }

        public ICollection<DetailService>? DetailServices { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }
        public ICollection<Product>? Productos { get; set; }
    }
}
