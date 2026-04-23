namespace HandlingExtinguishers.Models.Prices;

using HandlingExtinguishers.Models.Products;

public class PriceResponse
{
    public Guid? ProductId { get; set; }

    public int? DeatailServiceId  { get; set; }

    public string? Description { get; set; }

    public decimal? Value { get; set; }

    public decimal? Tax { get; set; }


    public ProductRequest? Product { get; set; }
}
