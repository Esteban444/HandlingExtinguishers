namespace HandlingExtinguishers.Models.Inventories;

using HandlingExtinguishers.Models.Extinguishers;
using HandlingExtinguishers.Models.Products;

public class InventarioRequest
{
    public Guid InventaryId { get; set; }

    public Guid? ProductId { get; set; }
   
    public DateTime? Date { get; set; }

    public string? Description { get; set; }

    public Guid? TypeExtinguisherId { get; set; }

    public Guid? WeightExtinguisherId { get; set; }

    public int? Quantity { get; set; }
    
    public DateTime? ExpirationDate { get; set; }

    public Guid? ServiceDetailId { get; set; }

    public ProductRequest? Product { get; set; }

    public WightExtinguisherRequest? WeightExtinguisher { get; set; }

    public TypeExtinguisherRequest? TypeExtinguisher { get; set; }
}
