namespace HandlingExtinguishers.Models.Models;

public class CreditService
{
    public Guid CreditServiceId { get; set; }

    public Guid? ServiceId { get; set; }

    public decimal? Advances { get; set; }

    public decimal? Debt { get; set; }

    public DateTime? Date { get; set; }

    public Service? Service { get; set; }
}
