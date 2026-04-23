namespace HandlingExtinguishers.Models.Clients;

public class ClientResponse
{
    public Guid ClientId { get; set; }

    public decimal? DocumentNumber { get; set; }

    public string? Name { get; set; }

    public string? LasName { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Nit { get; set; }
}
