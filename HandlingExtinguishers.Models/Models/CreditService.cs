namespace HandlingExtinguishers.Dto.Models
{
    public class CreditService
    {
        public Guid Id { get; set; }
        public Guid? IdService { get; set; }
        public decimal? Advances { get; set; }
        public decimal? Debt { get; set; }
        public DateTime? Date { get; set; }

        public Service? Service { get; set; }
    }
}
