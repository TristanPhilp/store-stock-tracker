using store_stock_tracker.src.Tools;
using System.Text;
using System.Xml.Linq;
using store_stock_tracker.Models;
namespace store_stock_tracker.src.WebAPI.Utils
{
    public class InventoryWorker
    {
        //Returns the entire product Inventory
        public static List<Product> FullInventory()
        {
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> results = instance.SelectProducts($"SELECT * FROM Products'");
            return results;
        }

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

        //Returns all fuzzy matches for a given product name
        public static List<Product> SearchByName(string name)
        {
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> results = instance.SelectProducts($"SELECT * FROM Products WHERE Name LIKE '%{name}%'");
            return results;
        }
        
        //Returns all fuzzy mathces for a given supplier name
        public static List<Product> SearchBySupplier(string supplier)
        {
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> results = instance.SelectProducts($"SELECT * FROM Products WHERE Supplier LIKE '%{supplier}%'");
            return results;
        }

        //Returns all products where current stock quantity is below the restock threshhold.
        public static List<Product> RestockSearch()
        {
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> results = instance.SelectProducts($"SELECT * FROM Products WHERE Quantity <= RestockThreshold");
            return results;
        }

        //Increases or decrease the stock of a single product
        //Returns 0 if successful, 1 if unsuccessful, or 2 if there are no products with the given ID.
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

        //Sets the current stock quantitiy of a product
        //Returns 0 if successful, 1 if unsuccessful, or 2 if there are no products with the given ID.
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

        //Returns the entire history 
        public static List<ProductHistory> GetHistoryById(int id)
        {
            //TODO: Add range modifier
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<ProductHistory> results = instance.SelectHistory($"SELECT * FROM ProductHistories WHERE ProductId = '{id}'");
            return results;
        }
    }
}
