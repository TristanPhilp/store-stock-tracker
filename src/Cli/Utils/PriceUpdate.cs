using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Formats.Tar;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml.Linq;

namespace store_stock_tracker.src.Cli.Utils
{
    internal class PriceUpdater
    {
        public static void PriceUpdate() 
        {
            string Name;
            string SKU;
            decimal Price = 0.00m;
            SQLiteConnection sqlite = new SQLiteConnection("Data Source=inventory.db");
            var command = sqlite.CreateCommand();
            command.CommandText = @"SELECT * FROM Products";
            sqlite.Open();


            Console.WriteLine("Showing Prices...");
            Console.WriteLine("Please select from the following SKU: ");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Name = reader.GetString(1);
                    SKU = reader.GetString(2);
                    Price = reader.GetDecimal(4);
                    Console.WriteLine($"{SKU}: {Name} - {Price}\n");
                }
            }
            string SKUChoice = Console.ReadLine();
            command.CommandText = string.Format("SELECT * FROM Products WHERE Sku = '{0}'", SKUChoice);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Price = reader.GetDecimal(4);
                }
            }                
            Console.WriteLine($"Update Price by?");
            decimal PriceChoice = Convert.ToDecimal(Console.ReadLine());
            decimal NewPrice = Price + PriceChoice;
            command.CommandText = string.Format("UPDATE Products SET Price = '{0}' WHERE Sku = '{1}'", NewPrice, SKUChoice);
            command.ExecuteNonQuery();
            command.CommandText = string.Format("SELECT * FROM Products WHERE Sku = '{0}'", SKUChoice);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Name = reader.GetString(1);
                    SKU = reader.GetString(2);
                    Price = reader.GetDecimal(4);
                    Console.WriteLine($"\nNew Price of {Name} - {Price}\n");
                }
            }
           
        }
    }
}
