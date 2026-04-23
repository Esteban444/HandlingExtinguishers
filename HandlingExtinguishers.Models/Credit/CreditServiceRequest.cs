namespace HandlingExtinguishers.Models.Credit;

using HandlingExtinguishers.Models.Models;

public class CreditServiceRequest
{
    public Guid Id { get; set; }

    public Guid? IdService { get; set; }

    public decimal? Advances { get; set; }

    public decimal? Preview { get; set; }

    public decimal? Debt { get; set; }

    public DateTime? Date { get; set; }

    public Service? Service { get; set; }
}
