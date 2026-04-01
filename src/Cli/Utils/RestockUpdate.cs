using store_stock_tracker.src.Tools;

namespace store_stock_tracker.src.Cli.Utils
{
    internal class RestockUpdater
    {
        public static void RestockUpdate()
        {
            int RestockChoice = 0;
            Console.WriteLine("Please search by SKU: ");
            string SKUChoice = Console.ReadLine().ToUpper();
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> inventory = instance.SelectQuery($"SELECT * FROM Products WHERE SKU = '{SKUChoice}'");
            Console.WriteLine("Name                           |SKU             |Restock Threshold");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"{p.name,-30} |{p.sku,-15} |{p.restockThreshold,15}");
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
            inventory = instance.SelectQuery($"SELECT * FROM Products WHERE SKU = '{SKUChoice}'");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"\nNew Restock Threshold of {p.name} - {p.restockThreshold}\n");
            }
        }
    }
}
