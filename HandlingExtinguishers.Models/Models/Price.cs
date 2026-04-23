namespace HandlingExtinguishers.Models.Models;

public class Price
{
    public Guid PriceId { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? DetailServiceId { get; set; }

    public string? Description { get; set; }

    public decimal? Value { get; set; }

    public decimal? Iva { get; set; }

    public DetailService? DetailService { get; set; }

    public Product? Product { get; set; }
}
