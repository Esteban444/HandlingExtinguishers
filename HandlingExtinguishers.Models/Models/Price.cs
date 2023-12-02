
namespace HandlingExtinguishers.Models.Models
{
    public class Price
    {
        public Guid Id { get; set; }
        public Guid? IdProduct { get; set; }
        public Guid? IdDetailService { get; set; } = null;
        public string? Description { get; set; }
        public decimal? price { get; set; }
        public decimal? Iva { get; set; }

        public DetailService? DetailService { get; set; }
        public Product? Product { get; set; }
    }
}
