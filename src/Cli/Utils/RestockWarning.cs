using store_stock_tracker.src.Tools;
using store_stock_tracker.Models;
namespace store_stock_tracker.src.Cli.Utils
{
    internal class RestockWarning
    {
        public static void GetRestockWarning()
        {
            Console.WriteLine("Items With Low Stock: ");
            Console.WriteLine("Name                           |Sku             |Quantity |   Price|       Supplier");
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> inventory = instance.SelectProducts("SELECT * FROM Products");
            foreach (Product p in inventory)
            {
                if (p.Quantity <= p.Restock_Threshold)
                    Console.WriteLine($"{p.Name,-30} |{p.Sku,-15} |{p.Quantity,8} | {p.Price,7} | {p.Supplier,15}");
            }
        }
    }
}
