using store_stock_tracker.src.Tools;
using store_stock_tracker.Models;
namespace store_stock_tracker.src.Cli.Utils
{
    internal class PriceUpdater
    {
        public static void PriceUpdate()
        {
            int PriceChoice = 0;
            Console.WriteLine("Please search by Sku: ");
            string SKUChoice = Console.ReadLine().ToUpper();
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> inventory = instance.SelectQuery($"SELECT * FROM Products WHERE Sku = '{SKUChoice}'");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"{p.Name,-30} |{p.Sku,-15} |{p.Quantity,8} | {p.Price,7} | {p.Supplier,15}");
                Console.WriteLine($"Update Price To:");
                PriceChoice = Convert.ToInt32(Console.ReadLine());
            }
            inventory = instance.SelectQuery(string.Format("UPDATE Products SET Quantity = '{0}' WHERE Sku = '{1}'", PriceChoice, SKUChoice));
            inventory = instance.SelectQuery($"SELECT * FROM Products WHERE Sku = '{SKUChoice}'");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"\nNew Price of {p.Name} - {p.Price}\n");
            }


        }
    }
}
