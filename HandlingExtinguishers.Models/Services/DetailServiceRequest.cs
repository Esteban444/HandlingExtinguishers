namespace HandlingExtinguishers.Models.Services;

public class DetailServiceRequest
{
    public Guid DetailServiceId { get; set; }

    public Guid? ServiceId { get; set; }

    public string? Description { get; set; }

    public Guid? TypeExtinguisherId { get; set; }

    public Guid? WeightExtinguisherId { get; set; }

    public decimal? Value { get; set; }

    public int? Quantity { get; set; }

    public decimal? Total { get; set; }
}
