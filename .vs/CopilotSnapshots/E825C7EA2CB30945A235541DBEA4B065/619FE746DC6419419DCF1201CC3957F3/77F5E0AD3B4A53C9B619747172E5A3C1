namespace HandlingExtinguishers.Models.Models;

public class Service
{
    public Guid ServiceId { get; set; }

    public Guid? ClientId { get; set; }

    public Guid? EmployeeId { get; set; }

    public DateTime? ServiceDate { get; set; }

    public decimal? Price { get; set; }

    public string? StateService { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public DateTime? MaintenenceDate { get; set; }

    public decimal? Advance { get; set; }

    public Client? Client { get; set; }

    public Employee? Employee { get; set; }

    public ICollection<CreditService>? CreditServices { get; set; }

    public ICollection<DetailService>? DetailServices { get; set; }
}
