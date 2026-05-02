namespace HandlingExtinguishers.Models.Services;

public class ServiceRequest
{
    public Guid? ClientId { get; set; }

    public Guid? EmployeeId { get; set; }

    public DateTime? ServiceDate { get; set; }

    public decimal? Price { get; set; }

    public string? StateService { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public DateTime? MaintenenceDate { get; set; }

    public decimal? Advance { get; set; }

    public bool Active { get; set; }

    public List<DetailServiceRequest> Details { get; set; } = [];

}
