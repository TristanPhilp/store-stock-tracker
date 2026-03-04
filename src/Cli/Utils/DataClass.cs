using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Data.SQLite;
using System.Text;


namespace store_stock_tracker.src.Cli.Utils
{
    internal class DataClass
    {

        public static void GetSKU()
        {
            SQLiteConnection sqlite = new SQLiteConnection("Data Source=inventory.db");
            var command = sqlite.CreateCommand();
            command.CommandText = @"SELECT * FROM Products";
            sqlite.Open();
            using (var reader = command.ExecuteReader())
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
            SQLiteConnection sqlite = new SQLiteConnection("Data Source=inventory.db");
            var command = sqlite.CreateCommand();
            command.CommandText = @"SELECT * FROM Products";
            sqlite.Open();
            using (var reader = command.ExecuteReader())
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
            SQLiteConnection sqlite = new SQLiteConnection("Data Source=inventory.db");
            var command = sqlite.CreateCommand();
            command.CommandText = @"SELECT * FROM Products";
            sqlite.Open();
            using (var reader = command.ExecuteReader())
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
            SQLiteConnection sqlite = new SQLiteConnection("Data Source=inventory.db");
            var command = sqlite.CreateCommand();
            command.CommandText = @"SELECT * FROM Products";
            sqlite.Open();
            using (var reader = command.ExecuteReader())
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
            SQLiteConnection sqlite = new SQLiteConnection("Data Source=inventory.db");
            var command = sqlite.CreateCommand();
            command.CommandText = @"SELECT * FROM Products";
            sqlite.Open();
            using (var reader = command.ExecuteReader())
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
    }
}
