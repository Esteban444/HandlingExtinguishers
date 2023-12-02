namespace HandlingExtinguishers.Models.Models
{
    public class DetailExtinguisherClient
    {
        public Guid Id { get; set; }
        public Guid? IdClients { get; set; }
        public string? TypeExtinguisher { get; set; }
        public string? WeightExtinguisher { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? MaintenanceDate { get; set; }

        public Client? Clientes { get; set; }
        //public ICollection<DetalleServicioDetalleClientes>? DetalleServicioDetalleClientes { get; set; }
    }
}
