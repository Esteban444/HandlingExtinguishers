namespace HandlingExtinguishers.Models.Models;

public class WeightExtinguisher
{
    public Guid WeightExtinguisherId { get; set; }

    public int? WeightPound { get; set; }

    public ICollection<DetailService>? DetailServices { get; set; }

    public ICollection<Inventory>? Inventories { get; set; }

    public ICollection<Product>? Products { get; set; }
}
