using store_stock_tracker.src.Tools;

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
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> inventory = instance.SelectQuery($"SELECT * FROM Products WHERE SKU = '{SKUChoice}'");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"{p.name,-30} |{p.sku,-15} |{p.quantity,8} | {p.price,7} | {p.supplier,15}");
                Console.WriteLine($"Update Stock by?");
                int QuantityChoice = Convert.ToInt32(Console.ReadLine());
                NewQuantity = p.quantity + (QuantityChoice * sign);
            }
            instance.SelectQuery(string.Format("UPDATE Products SET Quantity = '{0}' WHERE Sku = '{1}'", NewQuantity, SKUChoice));
            inventory = instance.SelectQuery($"SELECT * FROM Products WHERE SKU = '{SKUChoice}'");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"\nNew Stock of {p.name} - {p.quantity}\n");
            }

        }
    }
}
