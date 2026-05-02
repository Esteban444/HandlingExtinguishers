namespace HandlingExtinguishers.Models.Models;

public class DetailService
{
    public Guid DetailServiceId { get;  private set; }

    public Guid? ServiceId { get; private set; }

    public string? Description { get; private set; }

    public Guid? TypeExtinguisherId { get; private set; }

    public Guid? WeightExtinguisherId { get; private set; }

    public decimal? Price { get; private set; }

    public int? Quantity { get; private set; }

    public decimal? Total { get; private set; }

    public Service? Service { get; set; }

    public WeightExtinguisher? WeightExtinguisher { get; set; }

    public ICollection<Price>? Prices { get; set; }

    public TypeExtinguisher? TypeExtinguisher { get; set; }

    public ICollection<Inventory>? Inventories { get; set; }

    public ICollection<DetailServiceDetailClient>? DetailServiceDetailClients { get; set; }

    public void Create( Guid? serviceId,
                        string? description,
                        Guid? typeExtinguisherId,
                        Guid? weightExtinguisherId,
                        decimal? price,
                        int? quantity,
                        decimal? total )
    {
        DetailServiceId = Guid.NewGuid();
        ServiceId = serviceId;
        Description = description;
        TypeExtinguisherId = typeExtinguisherId;
        WeightExtinguisherId = weightExtinguisherId;
        Price = price;
        Quantity = quantity;
        Total = total;
    }

    public void Update( Guid? serviceId,
                        string? description,
                        Guid? typeExtinguisherId,
                        Guid? weightExtinguisherId,
                        decimal? price,
                        int? quantity,
                        decimal? total )
    {
        if ( serviceId is not null ) ServiceId = serviceId;
        if ( description is not null ) Description = description;
        if ( typeExtinguisherId is not null ) TypeExtinguisherId = typeExtinguisherId;
        if ( weightExtinguisherId is not null ) WeightExtinguisherId = weightExtinguisherId;
        if ( price is not null ) Price = price;
        if ( quantity is not null && quantity > 0 ) Quantity = quantity;
        if ( total is not null && total > 0 ) Total = total;
    }

    public void Delete( Guid serviceId ) 
    { 
        DetailServiceId = serviceId;
    }
}
