namespace HandlingExtinguishers.Models.Clients;

using HandlingExtinguishers.Models.Models;

public class DetailExtinguisherClientResponse
{
    public Guid DetailExtinguisherClientId { get; set; }

    public Guid? IdClients { get; set; }

    public string? TypeExtinguisher { get; set; }

    public string? WeightExtinguisher { get; set; }

    public int? Quantity { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public DateTime? MaintenanceDate { get; set; }

    public Client? Client { get; set; }
}
