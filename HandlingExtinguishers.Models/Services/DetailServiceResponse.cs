namespace HandlingExtinguishers.Models.Services;

public class DetailServiceResponse
{
    public Guid DetailServiceId { get; set; }

    public string? Description { get; set; }

    public string? TypeExtinguisher { get; set; }

    public string? WeightExtinguisher { get; set; }

    public int? Quantity { get; set; }

    public decimal? Total { get; set; }
}