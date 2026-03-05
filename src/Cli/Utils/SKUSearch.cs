using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace store_stock_tracker.src.Cli.Utils
{
    internal class SKUSearcher
    {
        public static void SearchSKU()
        {
            SQLiteConnection sqlite = new SQLiteConnection("Data Source=inventory.db");
            var command = sqlite.CreateCommand();
            command.CommandText = @"SELECT * FROM Products";
            sqlite.Open();
            Console.WriteLine("Enter SKU To Search: ");
            string SKUChoice = Console.ReadLine();
            command.CommandText = string.Format("SELECT * FROM Products WHERE Sku = '{0}'", SKUChoice);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string Name = reader.GetString(1);
                    string SKU = reader.GetString(2);
                    int Quantity = reader.GetInt32(3);
                    decimal Price = reader.GetDecimal(4);
                    int Restock = reader.GetInt32(5);
                    Console.WriteLine($"{SKU}: Name: {Name} - Stock: {Quantity} - Price: {Price} - Restock Threshold: {Restock}\n");
                }
            }
        }
    }
}
