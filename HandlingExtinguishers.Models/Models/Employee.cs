namespace HandlingExtinguishers.Models.Models;

using System.Text.Json.Serialization;

public class Employee: BaseModel
{
    public Guid EmployeeId { get; private set; }

    public Guid? CompanyId { get; private set; }

    public string? FirstName { get; private set; }

    public string? SecondName { get; private set; }

    public string? LastName { get; private set; }

    public string? SecondLastName { get; private set; }

    public string? Address { get; private set; }

    public string? Phone { get; private set; }

    public string? Email { get; private set; }

    public bool Active { get;  private set; }

    [JsonIgnore]
    public Company? Company { get; set; }

    [JsonIgnore]
    public ICollection<Service>? Services { get; set; }

    public static Employee Create( Guid? companyId,
                                   string? firstName,
                                   string? secondName,
                                   string? lastName,
                                   string? secondLastName,
                                   string? address,
                                   string? phone,
                                   string? email,
                                   bool? active )
    {
        return new Employee
        {
            EmployeeId = Guid.NewGuid(),
            CompanyId = companyId,
            FirstName = firstName,
            SecondName = secondName,
            LastName = lastName,
            SecondLastName = secondLastName,
            Address = address,
            Phone = phone,
            Email = email,
            Active = true
        };
    }

    public void Update( string? firstName,
                        string? secondName,
                        string? lastName,
                        string? secondLastName,
                        string? address,
                        string? phone,
                        string? email,
                        bool? active )
    {
        if ( firstName is not null ) FirstName = firstName;
        if ( secondName is not null ) SecondName = secondName;
        if ( lastName is not null ) LastName = lastName;
        if ( secondLastName is not null ) SecondLastName = secondLastName;
        if ( address is not null ) Address = address;
        if ( phone is not null ) Phone = phone;
        if ( email is not null ) Email = email;

        Active = active ?? Active;
    }

    public void Deactivate() => Active = false;
}
