namespace HandlingExtinguishers.Models.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid? IdTypeExtinguisher { get; set; }
        public Guid? IdWeightExtinguisher { get; set; }
        public string? TypeProduct { get; set; }

        public WeightExtinguisher? WeightExtinguisher { get; set; }
        public TypeExtinguisher? TypeExtinguisher { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }
        public ICollection<Price>? Prices { get; set; }
    }
}
