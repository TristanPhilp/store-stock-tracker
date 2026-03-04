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
            string Name;
            string SKU;
            int Restock = 0;
            SQLiteConnection sqlite = new SQLiteConnection("Data Source=inventory.db");
            var command = sqlite.CreateCommand();
            command.CommandText = @"SELECT * FROM Products";
            sqlite.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Name = reader.GetString(1);
                    SKU = reader.GetString(2);
                    Restock = reader.GetInt32(5);
                    Console.WriteLine($"{SKU}: {Name} - {Restock}\n");
                }
            }
            string SKUChoice = Console.ReadLine();
            command.CommandText = string.Format("SELECT * FROM Products WHERE Sku = '{0}'", SKUChoice);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Restock = reader.GetInt32(5);
                }
            }                
            Console.WriteLine($"Update Price by?");
            int RestockChoice = Convert.ToInt32(Console.ReadLine());
            int NewRestock = Restock + RestockChoice;
            command.CommandText = string.Format("UPDATE Products SET RestockThreshold = '{0}' WHERE Sku = '{1}'", NewRestock, SKUChoice);
            command.ExecuteNonQuery();
            command.CommandText = string.Format("SELECT * FROM Products WHERE Sku = '{0}'", SKUChoice);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Name = reader.GetString(1);
                    SKU = reader.GetString(2);
                    Restock = reader.GetInt32(5);
                    Console.WriteLine($"\nNew Restock Threshold of {Name} - {Restock}\n");
                }
            }
           
        }
    }
}
