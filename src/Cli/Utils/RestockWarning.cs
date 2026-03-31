using store_stock_tracker.src.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace store_stock_tracker.src.Cli.Utils
{
    internal class RestockWarning
    {
        public static void GetRestockWarning()
        {
            Console.WriteLine("Items With Low Stock: ");
            Console.WriteLine("Name                           |SKU             |Quantity |   Price|       Supplier");
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> inventory = instance.SelectQuery("SELECT * FROM Products");
            foreach (Product p in inventory)
            {
                if (p.quantity <= p.restockThreshold)
                    Console.WriteLine($"{p.name,-30} |{p.sku,-15} |{p.quantity,8} | {p.price,7} | {p.supplier,15}");
            }
        }
    }
}
