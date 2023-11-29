namespace HandlingExtinguisher.Dto.Clients
{
    public class BaseDetailExtinguisherClient
    {
        public Guid? IdClients { get; set; }
        public string? TypeExtinguisher { get; set; }
        public string? WeightExtinguisher { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? MaintenanceDate { get; set; }
    }
}
