using store_stock_tracker.Models;
using store_stock_tracker.src.Tools;

namespace store_stock_tracker.src.Cli.Utils
{
    internal class ConvertNameToSku
    {
        public static string NameToSku(string name)
        {
            var Sku = "";
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> inventory = instance.SelectProducts($"SELECT * FROM Products WHERE Name = '{name}'");
            foreach (Product p in inventory)
            {
                Sku = p.Sku;
            }

            return Sku;
        }
    }
}
