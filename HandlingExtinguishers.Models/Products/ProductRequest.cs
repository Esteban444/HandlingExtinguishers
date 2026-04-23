namespace HandlingExtinguishers.Models.Products;

using HandlingExtinguishers.Models.Extinguishers;

public class ProductRequest
{
    public Guid ProductId { get; set; }

    public Guid? TypeExtinguisherId { get; set; }

    public Guid? WeightExtinguisherId { get; set; }

    public string? ProductType { get; set; }

    public WightExtinguisherRequest? WightExtinguisher { get; set; }

    public TypeExtinguisherRequest? TypeExtinguisher { get; set; }
}
