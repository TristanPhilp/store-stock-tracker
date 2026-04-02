using store_stock_tracker.src.Tools;

namespace store_stock_tracker.src.Cli.Utils
{
    internal class PriceUpdateSkipSearcher
    {
        public static void PriceUpdate(string Sku)
        {
            int PriceChoice = 0;
            string SKUChoice = Sku;
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
