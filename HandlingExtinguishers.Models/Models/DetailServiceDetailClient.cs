namespace HandlingExtinguishers.Models.Models;

public class DetailServiceDetailClient
{
    public Guid DetailServiceDetailClientId { get; set; }

    public Guid? DetailServiceId { get; set; }

    public Guid? DetailExtinguisherClientId { get; set; }

    public DetailExtinguisherClient? DetailExtinguisherClient { get; set; }

    public DetailService? DetailService { get; set; }
}
