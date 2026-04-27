using System.Text.Json.Serialization;

namespace HandlingExtinguishers.Models.Models;

public class DetailExtinguisherClient
{
    public Guid DetailExtinguisherClientId { get; set; }

    public Guid? ClientId { get; set; }

    public string? TypeExtinguisher { get; set; }

    public string? WeightExtinguisher { get; set; }

    public int? Quantity { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public DateTime? MaintenanceDate { get; set; }

    [JsonIgnore]
    public Client? Client { get; set; }

    [JsonIgnore]
    public ICollection<DetailServiceDetailClient>? DetailServiceDetailClients { get; set; }
}
