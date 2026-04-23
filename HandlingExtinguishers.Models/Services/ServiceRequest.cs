namespace HandlingExtinguishers.Models.Services;

using HandlingExtinguishers.Models.Employees;
using HandlingExtinguishers.Models.Models;

public class ServiceRequest
{
    public Guid IdService { get; set; }

    public Guid? IdClient { get; set; }

    public Guid? IdEmployee { get; set; }
  
    public DateTime? ServiceDate { get; set; }

    public decimal? Price { get; set; } 

    public string? Status { get; set; }
    
    public DateTime? ExpirationDate { get; set; }
   
    public DateTime? MaintenanceDate { get; set; }

    public decimal? Preview { get; set; }

    public Client? Client { get; set; }

    public EmployeeResponse? Employee { get; set; }

    public List<DetailServiceRequest>? ServiceDetails { get; set; }
}
