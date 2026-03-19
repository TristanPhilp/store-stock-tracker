using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Threading;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using store_stock_tracker.src.Cli.Utils;


namespace store_stock_tracker.src.Cli.Utils
{
    //Class for managing products
    public class Product()
    {
        public int id { get; set; }

        public string name { get; set; }

        public string sku { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }

        public int restockThreshold {  get; set; }

        public string supplier { get; set; }
    }

    //Singleton accessor class to control flow in and out of the database
    internal class ProductAccessor
    {
        private static SQLiteConnection connection;

        private static ProductAccessor instance;

        private ProductAccessor()
        {
            connection = new SQLiteConnection("Data Source=inventory.db");
            connection.Open();
        }


        //If there's no instance ready, create one. Otherwise, return the managed instance.
        public static ProductAccessor GetInstance()
        {
            if (instance == null)
            {
                //TODO HERE
                //Acquire a thread lock
               instance = new ProductAccessor();
            }
            return instance;
        }

        //When queried, creates a list of products and returns it.
        public List<Product> Query(string query)
        {
            List<Product> products = new List<Product>();
            if (Validators.IsValidSelectQuery(query, "Products"))
            {
                var command = connection.CreateCommand();
                command.CommandText = query;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.id = reader.GetInt32(0);
                        product.name = reader.GetString(1);
                        product.sku = reader.GetString(2);
                        product.quantity = reader.GetInt32(3);
                        product.price = reader.GetDecimal(4);
                        product.restockThreshold = reader.GetInt32(5);
                        product.supplier = reader.GetString(6);

                        products.Add(product);
                    }
                }
            }
            return products;
            
        }

        
        

        /*
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
            while (reader.Read())
            {
                string Name = reader.GetString(1);
                string SKU = reader.GetString(2);
                decimal Price = reader.GetDecimal(4);
                Console.WriteLine($"{SKU}: {Name} - {Price} \n");
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
        */
    }
}
