using System.Data;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace HandlingExtinguishers.Models.Models;

public class Service
{
    public Guid ServiceId { get; private set; }

    public Guid? ClientId { get; private set; }

    public Guid? EmployeeId { get; private set; }

    public DateTime? ServiceDate { get; private set; }

    public decimal? Price { get; private set; }

    public string? StateService { get; private set; }

    public DateTime? ExpirationDate { get; private set; }

    public DateTime? MaintenenceDate { get; private set; }

    public decimal? Advance { get; private set; }

    public bool Active { get; private set; }

    public Client? Client { get; set; }

    public Employee? Employee { get; set; }

    public ICollection<CreditService>? CreditServices { get; set; }

    public ICollection<DetailService>? DetailServices { get; set; }


    private Service() { }

    public static Service Create( Guid? clientId,
                                  Guid? employeeId,
                                  DateTime? serviceDate,
                                  decimal? price,
                                  string? stateService,
                                  DateTime? expirationDate,
                                  DateTime? maintenenceDate,
                                  decimal? advance )
    {
        return new Service
        {
            ClientId = clientId,
            EmployeeId = employeeId,
            ServiceDate = serviceDate,
            Price = price,
            StateService = stateService,
            ExpirationDate = expirationDate,
            MaintenenceDate = maintenenceDate,
            Advance = advance,
            Active = true
        };
    }

    public void Update( Guid? clientId, Guid? employeeId, DateTime? serviceDate,
                       decimal? price, string? stateService, DateTime? expirationDate,
                       DateTime? maintenenceDate, decimal? advance, bool? active )
    {
        if ( clientId is not null ) ClientId = clientId;
        if ( employeeId is not null ) EmployeeId = employeeId;
        if ( serviceDate is not null ) ServiceDate = serviceDate;
        if ( price is not null ) Price = price;
        if ( stateService is not null ) StateService = stateService;
        if ( expirationDate is not null ) ExpirationDate = expirationDate;
        if ( maintenenceDate is not null ) MaintenenceDate = maintenenceDate;
        if ( advance is not null) Advance = advance  ;
        Active = active ?? Active;
    }

    public void Deactivate() => Active = false;
}
