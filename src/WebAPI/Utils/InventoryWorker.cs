using store_stock_tracker.src.Tools;
using System.Text;
using System.Xml.Linq;
using store_stock_tracker.Models;
namespace store_stock_tracker.src.WebAPI.Utils
{
    public class InventoryWorker
    {
        //Returns the first fuzzy match for a given SKU code
        public static Product SearchBySKU(string sku)
        {
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> results = instance.SelectProducts($"SELECT * FROM Products WHERE Sku LIKE '%{sku.ToUpper()}%'");
            if ( results.Count > 0 )
            {
                return results[0];
            }
            else { return new Product(); }
        }

        //Returns all fuzzy matches for a given string interpreted as a product name
        public static List<Product> SearchByName(string name)
        {
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> results = instance.SelectProducts($"SELECT * FROM Products WHERE Name LIKE '%{name}%'");
            return results;
        }
        
        public static List<Product> SearchBySupplier(string supplier)
        {
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> results = instance.SelectProducts($"SELECT * FROM Products WHERE Supplier LIKE '%{supplier}%'");
            return results;
        }

        public static List<Product> RestockSearch()
        {
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> results = instance.SelectProducts($"SELECT * FROM Products WHERE Quantity <= RestockThreshold");
            return results;
        }

        public static int UpdateStock(int id, int amount)
        {
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> products = instance.SelectProducts($"SELECT * FROM Products WHERE ID = '{id}'");
            if (products.Count == 1)
            {
                if (instance.QueryProducts($"UPDATE Products SET Quantity = '{products[0].Quantity + amount}' WHERE ID = '{id}'", InventoryAccessor.actionType.updateQuantity, id) == 0)
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

        public static int SetStock(int id, int amount)
        {
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> products = instance.SelectProducts($"SELECT * FROM Products WHERE ID = '%{id}%'");
            if (products.Count == 1)
            {
                if (instance.QueryProducts($"UPDATE Products SET Quantity = '{amount}' WHERE ID = '{id}'", InventoryAccessor.actionType.updateQuantity, id) == 0)
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
