namespace HandlingExtinguishers.Models.Models;

public class TypeExtinguisher
{
    public Guid TypeExtinguisherId { get; set; }

    public string? Extinguisher { get; set; }

    public ICollection<DetailService>? DetailServices { get; set; }

    public ICollection<Inventory>? Inventories { get; set; }

    public ICollection<Product>? Productos { get; set; }
}
