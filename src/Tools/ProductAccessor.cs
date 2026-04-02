using store_stock_tracker.src.Interfaces;
using System.Data.SQLite;


namespace store_stock_tracker.src.Tools
{
    //Class for managing products
    public class Product()
    {
        public int id { get; set; }

        public string name { get; set; }

        public string sku { get; set; }

        public int quantity { get; set; }

        public decimal price { get; set; }

        public int restockThreshold { get; set; }

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
        public List<Product> SelectQuery(string query)
        {
            IValidationStrategy strategy = new SelectValidator();
            List<Product> products = new List<Product>();
            if (strategy.Validate(query, "Products"))
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

        public int Query(string query, string type)
        {
            IValidationStrategy strategy =
            type.ToLower() switch
            {
                "update" => new UpdateValidator(),
                "delete" => new DeleteValidator(),
                "insert" => new InsertValidator(),
                _ => new SelectValidator()
            };
            if (strategy.Validate(query, "Products"))
            {
                var command = connection.CreateCommand();
                command.CommandText = query;
                command.ExecuteReader();
                return 0;
            }
            else { return 1; }
        }
    }
}
