namespace HandlingExtinguishers.Models.Services;

public class DetailServiceRequest
{
    public Guid? ServiceId { get; set; }

    public string? Description { get; set; }

    public Guid? TypeExtinguisherId { get; set; }

    public Guid? WeightExtinguisherId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public decimal? Total { get; set; }
}
