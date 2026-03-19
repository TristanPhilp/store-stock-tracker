using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Formats.Tar;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml.Linq;

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
            List<Product> inventory = instance.Query($"SELECT * FROM Products WHERE SKU = '{SKUChoice}'");
            Console.WriteLine("Name            |SKU             |Restock Threshold");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"{p.name,-15} |{p.sku,-15} |{p.restockThreshold,15}");
            }
            Console.WriteLine($"Change Restock Threshold to: ");
            RestockChoice = Convert.ToInt32(Console.ReadLine());
            inventory = instance.Query(string.Format("UPDATE Products SET RestockThreshold = '{0}' WHERE Sku = '{1}'", RestockChoice, SKUChoice));
            inventory = instance.Query($"SELECT * FROM Products WHERE SKU = '{SKUChoice}'");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"\nNew Restock Threshold of {p.name} - {p.restockThreshold}\n");
            }           
        }
    }
}
