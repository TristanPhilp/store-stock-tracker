using store_stock_tracker.src.Tools;
using store_stock_tracker.Models;
namespace store_stock_tracker.src.Cli.Utils
{
    internal class RestockUpdateSkipSearcher
    {
        /*
         * TODO: Change this so that it can provide an id to the QueryProducts method.
        public static void RestockUpdate(string Sku)
        {
            int RestockChoice = 0;
            string SKUChoice = Sku;
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> inventory = instance.SelectProducts($"SELECT * FROM Products WHERE Sku = '{SKUChoice}'");
            Console.WriteLine("Name                           |Sku             |Restock Threshold");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"{p.Name,-30} |{p.Sku,-15} |{p.Restock_Threshold,15}");
            }
            Console.WriteLine($"Change Restock Threshold to: ");
            RestockChoice = Convert.ToInt32(Console.ReadLine());
            if (instance.QueryProducts(string.Format("UPDATE Products SET RestockThreshold = '{0}' WHERE Sku = '{1}'", RestockChoice, SKUChoice), "update") == 0)
            {
                Console.WriteLine("Update Successful");
            }
            else
            {
                Console.WriteLine("Update Not Successful");
            }
            inventory = instance.SelectProducts($"SELECT * FROM Products WHERE Sku = '{SKUChoice}'");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"\nNew Restock Threshold of {p.Name} - {p.Restock_Threshold}\n");
            }
        }
        */
    }
}
