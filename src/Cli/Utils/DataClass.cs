using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Data.SQLite;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace store_stock_tracker.src.Cli.Utils
{
    internal class DataClass
    {
        public static void GetFullTable()
        {
            Console.WriteLine("Showing Table");
            using (var reader = OpenDataReader())
            {
                Console.WriteLine("Name            |SKU             |Quantity |   Price | Restock Threshold");
                while (reader.Read())
                {
                    string Name = reader.GetString(1);
                    string SKU = reader.GetString(2);
                    int Quantity = reader.GetInt32(3);
                    decimal Price = reader.GetDecimal(4);
                    int Restock = reader.GetInt32(5);
                    Console.WriteLine($"{Name,-15} |{SKU,-15} |{Quantity,8} | {Price,7} | {Restock,17}");
                }
            }

        }
        public static void GetSKU()
        { 
            using (var reader = OpenDataReader())
            {
                while (reader.Read())
                {
                    string Name = reader.GetString(1);
                    string SKU = reader.GetString(2);
                    Console.WriteLine($"{Name}: {SKU}\n");
                }
            }
        }
        
        public static void GetStock()
        {
            using (var reader = OpenDataReader())
            {
                while (reader.Read())
                {
                    string Name = reader.GetString(1);
                    string SKU = reader.GetString(2);
                    int Quantity = reader.GetInt32(3);
                    Console.WriteLine($"{SKU}: {Name} - {Quantity} \n");
                }
            }
        }

        public static void GetPrice()
        {
            using (var reader = OpenDataReader())
            {
                while (reader.Read())
                {
                    string Name = reader.GetString(1);
                    string SKU = reader.GetString(2);
                    decimal Price = reader.GetDecimal(4);
                    Console.WriteLine($"{SKU}: {Name} - {Price} \n");
                }
            }
        }
        public static void GetRestockWarning()
        {
            Console.WriteLine("Showing Items With Low Stock...");
            using (var reader = OpenDataReader())
            {
                while (reader.Read())
                {
                    string Name = reader.GetString(1);
                    string SKU = reader.GetString(2);
                    int Quantity = reader.GetInt32(3);
                    int Restock = reader.GetInt32(5);
                    if (Quantity <= Restock)
                        Console.WriteLine($"{SKU}: {Name} - {Quantity} Remaining \n");
                }
            }
        }
        public static void GetRestockThreshold()
        {
            Console.WriteLine("Current Restock Warnings...");
            using (SQLiteDataReader reader = OpenDataReader())
            {
                while (reader.Read())
                {
                    string Name = reader.GetString(1);
                    string SKU = reader.GetString(2);
                    int Restock = reader.GetInt32(5);
                    Console.WriteLine($"{SKU}: {Name} - {Restock} \n");
                }
            }
        }

        public static SQLiteDataReader OpenDataReader()
        {
            SQLiteConnection sqlite = new SQLiteConnection("Data Source=inventory.db");
            var command = sqlite.CreateCommand();
            command.CommandText = @"SELECT * FROM Products";
            sqlite.Open();
            return command.ExecuteReader();
        }
    }
}
