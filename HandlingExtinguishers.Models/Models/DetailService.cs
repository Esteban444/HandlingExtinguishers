namespace HandlingExtinguishers.Models.Models
{
    public class DetailService
    {
        public Guid Id { get; set; }
        public Guid? IdService { get; set; }
        public string? Description { get; set; }
        public Guid? IdTypeExtinguisher { get; set; }
        public Guid? IdWeightExtinguisher { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }

        public Service? Service { get; set; }
        public WeightExtinguisher? WeightExtinguisher { get; set; }
        public ICollection<Price>? Prices { get; set; }
        public TypeExtinguisher? TypeExtinguisher { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }
        //public ICollection<DetalleServicioDetalleClientes>? DetalleServicioDetalleClientes { get; set; }
    }
}
