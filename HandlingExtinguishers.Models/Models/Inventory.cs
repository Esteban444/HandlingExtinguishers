namespace HandlingExtinguishers.Models.Models
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public Guid? IdProduct { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public Guid? IdTypeExtinguisher { get; set; }
        public Guid? IdWeigthExtinguisher { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Guid? DetailServiceId { get; set; } = null;

        public Product? Product { get; set; }
        public DetailService? DetailService { get; set; }
        public WeightExtinguisher? WeightExtinguisher { get; set; }
        public TypeExtinguisher? TypeExtinguisher { get; set; }
    }
}
