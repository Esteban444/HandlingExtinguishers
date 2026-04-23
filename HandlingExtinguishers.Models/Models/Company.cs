
namespace HandlingExtinguishers.Models.Models;

public class Company : BaseModel
{
    public Guid CompanyId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Nit { get; set; }

    public bool Active { get; set; }

    public ICollection<Employee>? Employee { get; set; }
}
