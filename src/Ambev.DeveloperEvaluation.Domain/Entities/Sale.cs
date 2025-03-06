public class Sale
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public string Customer { get; set; } = string.Empty;
    public decimal TotalValue { get; set; }
    public string Store { get; set; } = string.Empty;
    public List<SaleItem> Items { get; set; } = new();

    public bool IsCancelled { get; set; }

    public void CalculateTotal()
    {
        TotalValue = Items.Sum(item => item.TotalValue);
    }
}
