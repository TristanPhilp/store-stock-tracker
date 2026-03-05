using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml.Linq;

namespace store_stock_tracker.src.Cli.Utils
{
    internal class StockUpdater
    {
        public static void StockUpdate() 
        {
            string Name;
            string SKU;
            int Quantity = 0;
            SQLiteConnection sqlite = new SQLiteConnection("Data Source=inventory.db");
            var command = sqlite.CreateCommand();
            command.CommandText = @"SELECT * FROM Products";


            Console.WriteLine("Showing Current Stock...");
            Console.WriteLine("Please select from the following SKU: ");
            sqlite.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Name = reader.GetString(1);
                    SKU = reader.GetString(2);
                    Quantity = reader.GetInt32(3);
                    Console.WriteLine($"{SKU}: {Name} - {Quantity}\n");
                }
            }
            string SKUChoice = Console.ReadLine();
            command.CommandText = string.Format("SELECT * FROM Products WHERE Sku = '{0}'", SKUChoice);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Quantity = reader.GetInt32(3);
                }
            }                
            Console.WriteLine($"Update Stock by?");
            int QuantityChoice = Convert.ToInt32(Console.ReadLine());
            int NewQuantity = Quantity + QuantityChoice;
            command.CommandText = string.Format("UPDATE Products SET Quantity = '{0}' WHERE Sku = '{1}'", NewQuantity, SKUChoice);
            command.ExecuteNonQuery();
            command.CommandText = string.Format("SELECT * FROM Products WHERE Sku = '{0}'", SKUChoice);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Name = reader.GetString(1);
                    SKU = reader.GetString(2);
                    Quantity = reader.GetInt32(3);
                    Console.WriteLine($"\nNew Stock of {Name} - {Quantity}\n");
                }
            }
           
        }
    }
}
