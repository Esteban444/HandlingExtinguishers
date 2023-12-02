namespace HandlingExtinguishers.Models.Models
{
    public class Expense
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }
    }
}
