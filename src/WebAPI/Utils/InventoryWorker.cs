using store_stock_tracker.src.Tools;
using System.Text;
using System.Xml.Linq;

namespace store_stock_tracker.src.WebAPI.Utils
{
    public class InventoryWorker
    {
        public Product SearchBySKU(string sku)
        {
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> results = instance.SelectQuery($"SELECT * FROM Products WHERE SKU = '{sku.ToUpper()}'");
            if ( results.Count > 0 )
            {
                return results[0];
            }
            else { return new Product(); }
        }

        public List<Product> SearchByName(string name)
        {
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> results = instance.SelectQuery($"SELECT * FROM Products WHERE Name LIKE '%{name}%'");
            return results;
        }
        public List<Product> SearchBySupplier(string supplier)
        {
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> results = instance.SelectQuery($"SELECT * FROM Products WHERE Supplier LIKE '%{supplier}%'");
            return results;
        }

        public List<Product> RestockSearch()
        {
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> results = instance.SelectQuery($"SELECT * FROM Products WHERE Quantity <= RestockThreshold");
            return results;
        }

        public int UpdateStock(int id, int amount)
        {
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> products = instance.SelectQuery($"SELECT * FROM Products WHERE ID = '%{id}%'");
            if (products.Count == 1)
            {
                if (instance.Query($"UPDATE Products SET Quantity = '{products[0].quantity + amount}' WHERE ID = '{id}'", "update") == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 2;
            }
        }

        public int SetStock(int id, int amount)
        {
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> products = instance.SelectQuery($"SELECT * FROM Products WHERE ID = '%{id}%'");
            if (products.Count == 1)
            {
                if (instance.Query($"UPDATE Products SET Quantity = '{amount}' WHERE ID = '{id}'", "update") == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 2;
            }
        }
    }
}
