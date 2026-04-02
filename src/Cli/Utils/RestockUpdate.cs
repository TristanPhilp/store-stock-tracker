using store_stock_tracker.src.Tools;
using store_stock_tracker.Models;
namespace store_stock_tracker.src.Cli.Utils
{
    internal class RestockUpdater
    {
        public static void RestockUpdate()
        {
            int RestockChoice = 0;
            Console.WriteLine("Please search by Sku: ");
            string SKUChoice = Console.ReadLine().ToUpper();
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> inventory = instance.SelectQuery($"SELECT * FROM Products WHERE Sku = '{SKUChoice}'");
            Console.WriteLine("Name                           |Sku             |Restock Threshold");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"{p.Name,-30} |{p.Sku,-15} |{p.Restock_Threshold,15}");
            }
            Console.WriteLine($"Change Restock Threshold to: ");
            RestockChoice = Convert.ToInt32(Console.ReadLine());
            if (instance.Query(string.Format("UPDATE Products SET RestockThreshold = '{0}' WHERE Sku = '{1}'", RestockChoice, SKUChoice), "update") == 0)
            {
                Console.WriteLine("Update Successful");
            }
            else
            {
                Console.WriteLine("Update Not Successful");
            }
            inventory = instance.SelectQuery($"SELECT * FROM Products WHERE Sku = '{SKUChoice}'");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"\nNew Restock Threshold of {p.Name} - {p.Restock_Threshold}\n");
            }
        }
    }
}
