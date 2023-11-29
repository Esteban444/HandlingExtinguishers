
namespace HandlingExtinguishers.Dto.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public decimal? DocumentClient { get; set; }
        public string? Name { get; set; }
        public string? LasName { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Nit { get; set; }

        public ICollection<DetailExtinguisherClient>? DetalleExtClientes { get; set; }
        public ICollection<Service>? Services { get; set; }
    }
}
