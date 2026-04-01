namespace store_stock_tracker.src.Interfaces
{
    public interface IValidationStrategy
    {
        public  bool Validate(string query, string allowedTable);
    }
}
