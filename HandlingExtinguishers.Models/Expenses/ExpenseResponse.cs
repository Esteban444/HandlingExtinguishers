namespace HandlingExtinguishers.Models.Expenses;

using System.ComponentModel.DataAnnotations;

public class ExpenseResponse
{
    public int ExpenseId { get; set; } 

    public string? Description { get; set; }

  
    public DateTime? Date { get; set; }

    public int? Quantity { get; set; }

    public decimal Total { get; set; }
}
