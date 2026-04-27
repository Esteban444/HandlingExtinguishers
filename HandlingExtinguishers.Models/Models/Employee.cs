using System.Text.Json.Serialization;

namespace HandlingExtinguishers.Models.Models;

public class Employee: BaseModel
{
    public Guid EmployeeId { get; set; }

    public Guid? CompanyId { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? LastName { get; set; }

    public string? SecondLastName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public bool Active { get; set; }

    [JsonIgnore]
    public Company? Company { get; set; }

    [JsonIgnore]
    public ICollection<Service>? Services { get; set; }
}
