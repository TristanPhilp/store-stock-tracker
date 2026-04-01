using store_stock_tracker.src.Tools;
using System.Text;

namespace store_stock_tracker.src.WebAPI.Utils
{
    public class Searcher
    {
        public static Product SearchBySKU(string sku)
        {
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> results = instance.SelectQuery($"SELECT * FROM Products WHERE SKU = '{sku.ToUpper()}'");
            if ( results.Count > 0 )
            {
                return results[0];
            }
            else { return new Product(); }
        }

        public static List<Product> SearchByName(string name)
        {
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> results = instance.SelectQuery($"SELECT * FROM Products WHERE Name LIKE '%{name}%'");
            return results;
        }
    }
}
