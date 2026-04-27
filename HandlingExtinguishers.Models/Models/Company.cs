namespace HandlingExtinguishers.Models.Models;

public class Company : BaseModel
{
    public Guid CompanyId { get; private set; }
    public string? Name { get; private set; }
    public string? Address { get; private set; }
    public string? Phone { get; private set; }
    public string? Email { get; private set; }
    public string? Nit { get; private set; }
    public bool Active { get; private set; }
    public ICollection<Employee>? Employee { get; private set; }

    private Company() { }

    public static Company Create( string name, string? address, string? phone,
                                  string? email, string nit )
    {
        return new Company
        {
            CompanyId = Guid.NewGuid(),
            Name = name,
            Address = address,
            Phone = phone,
            Email = email,
            Nit = nit,
            Active = true
        };
    }

    public void Update( string? name, string? address, string? phone,
                       string? email, string? nit, bool? active )
    {
        if ( name is not null ) Name = name;
        if ( address is not null ) Address = address;
        if ( phone is not null ) Phone = phone;
        if ( email is not null ) Email = email;
        if ( nit is not null ) Nit = nit;
        Active = active ?? Active;
    }

    public void Deactivate() => Active = false;
}