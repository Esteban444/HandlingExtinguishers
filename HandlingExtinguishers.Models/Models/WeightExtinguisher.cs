namespace HandlingExtinguishers.Models.Models
{
    public class WeightExtinguisher
    {
        public Guid Id { get; set; }
        public int? WeightPound { get; set; }

        public ICollection<DetailService>? DetaileService { get; set; }
        public ICollection<Inventory>? Inventory { get; set; }
        public ICollection<Product>? Product { get; set; }
    }
}
