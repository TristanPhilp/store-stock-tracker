using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Data.SQLite;
using System.Text;


namespace store_stock_tracker.src.Cli.Utils
{
    internal class DataClass
    {

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
                    var id = reader.GetInt32(0);
                    string Name = reader.GetString(1);
                    string SKU = reader.GetString(2);
                    int Quantity = reader.GetInt32(3);
                    Console.WriteLine($"{id}: {Name} - {SKU} - {Quantity}");
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
                    var id = reader.GetInt32(0);
                    string Name = reader.GetString(1);
                    string SKU = reader.GetString(2);
                    decimal Price = reader.GetDecimal(4);
                    Console.WriteLine($"{id}: {Name} - {SKU} - {Price}");
                }
            }
        }
    }
}
