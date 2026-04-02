namespace store_stock_tracker.Models
{
    public class ProductHistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductSKU { get; set; }= string.Empty;
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public string Action { get; set; } = string.Empty;
        // "insterted", "QuantityUpdate", "PriceUpdate", "RestockUpdate", "Deleted", 
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
