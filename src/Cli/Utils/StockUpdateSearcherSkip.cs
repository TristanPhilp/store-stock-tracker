using store_stock_tracker.src.Tools;
using store_stock_tracker.Models;
namespace store_stock_tracker.src.Cli.Utils
{
    internal class StockUpdateSkipSearcher
    {
        public static void StockUpdate(string choice, string Sku)
        {
            int sign = 0;

            if (Convert.ToInt32(choice) == 3 || Convert.ToInt32(choice) == 1)
            {
                sign = -1;
            }
            else if (Convert.ToInt32(choice) == 4 || Convert.ToInt32(choice) == 2)
            {
                sign = 1;
            }
            int NewQuantity = 0;
            string SKUChoice = Sku;
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> inventory = instance.SelectProducts($"SELECT * FROM Products WHERE Sku = '{SKUChoice}'");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"{p.Name,-30} |{p.Sku,-15} |{p.Quantity,8} | {p.Price,7} | {p.Supplier,15}");
                Console.WriteLine($"Update Stock by?");
                int QuantityChoice = Convert.ToInt32(Console.ReadLine());
                NewQuantity = p.Quantity + (QuantityChoice * sign);
            }
            instance.SelectProducts(string.Format("UPDATE Products SET Quantity = '{0}' WHERE Sku = '{1}'", NewQuantity, SKUChoice));
            inventory = instance.SelectProducts($"SELECT * FROM Products WHERE Sku = '{SKUChoice}'");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"\nNew Stock of {p.Name} - {p.Quantity}\n");
            }

        }
    }
}
