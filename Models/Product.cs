namespace store_stock_tracker.Models
{
    //Simple product model
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
