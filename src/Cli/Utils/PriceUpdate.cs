using store_stock_tracker.src.Tools;

namespace store_stock_tracker.src.Cli.Utils
{
    internal class PriceUpdater
    {
        public static void PriceUpdate()
        {
            int PriceChoice = 0;
            Console.WriteLine("Please search by SKU: ");
            string SKUChoice = Console.ReadLine().ToUpper();
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> inventory = instance.SelectQuery($"SELECT * FROM Products WHERE SKU = '{SKUChoice}'");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"{p.name,-30} |{p.sku,-15} |{p.quantity,8} | {p.price,7} | {p.supplier,15}");
                Console.WriteLine($"Update Price To:");
                PriceChoice = Convert.ToInt32(Console.ReadLine());
            }
            inventory = instance.SelectQuery(string.Format("UPDATE Products SET Quantity = '{0}' WHERE Sku = '{1}'", PriceChoice, SKUChoice));
            inventory = instance.SelectQuery($"SELECT * FROM Products WHERE SKU = '{SKUChoice}'");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"\nNew Price of {p.name} - {p.price}\n");
            }


        }
    }
}
