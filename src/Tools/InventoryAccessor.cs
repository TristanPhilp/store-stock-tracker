using store_stock_tracker.src.Interfaces;
using store_stock_tracker.Models;
using System.Data.SQLite;
using System.Collections.Generic;


namespace store_stock_tracker.src.Tools
{

    //Singleton accessor class to control flow in and out of the database
    internal class InventoryAccessor
    {
        private static SQLiteConnection connection;

        private static InventoryAccessor instance;

        

        private InventoryAccessor()
        {
            connection = new SQLiteConnection("Data Source=inventory.db");
            connection.Open();
        }


        //If there's no instance ready, create one. Otherwise, return the managed instance.
        public static InventoryAccessor GetInstance()
        {
            if (instance == null)
            {
                //TODO HERE
                //Acquire a thread lock
                instance = new InventoryAccessor();
            }
            return instance;
        }

        //When queried with a select statement, creates a list of products and returns it.
        //If given query is not validated as proper select query, returns an empty product
        public List<Product> SelectProducts(string query)
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
                        product.Id = reader.GetInt32(0);
                        product.Name = reader.GetString(1);
                        product.Sku = reader.GetString(2);
                        product.Quantity = reader.GetInt32(3);
                        product.Price = reader.GetDecimal(4);
                        product.Restock_Threshold = reader.GetInt32(5);
                        product.Supplier = reader.GetString(6);

                        products.Add(product);
                    }
                }
            }
            return products;

        }
        public int QueryProducts(string query, actionType type, int id)
        {
            IValidationStrategy strategy =
            type switch
            {
                actionType.updatePrice => new UpdateValidator(),
                actionType.updateQuantity => new UpdateValidator(),
                actionType.updateRestock => new UpdateValidator(),
                actionType.delete => new DeleteValidator(),
                actionType.insert => new InsertValidator(),
                _ => new SelectValidator()
            };
            if (strategy.Validate(query, "Products"))
            {
                var command = connection.CreateCommand();
                command.CommandText = query;
                command.ExecuteReader();
                InsertHistory(id, type);
                return 0;
            }
            else { return 1; }
        }

        public List<ProductHistory> SelectHistory(string query)
        {
            IValidationStrategy strategy = new SelectValidator();
            List<ProductHistory> histories = new List<ProductHistory>();
            if (strategy.Validate(query, "ProductHistories"))
            {
                var command = connection.CreateCommand();
                command.CommandText = query;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductHistory history = new ProductHistory();
                        history.Id = reader.GetInt32(0);
                        history.ProductId = reader.GetInt32(1);
                        history.ProductName = reader.GetString(2);
                        history.ProductSKU = reader.GetString(3);
                        history.ProductQuantity = reader.GetInt32(7);
                        history.ProductPrice = reader.GetDecimal(4);
                        history.Action = reader.GetString(5);
                        history.Timestamp = DateTime.Parse(reader.GetString(6));

                        histories.Add(history);
                    }
                }
            }
            return histories;

        }

        protected int InsertHistory(int id, actionType action)
        {
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Products WHERE ID = '{id}'";
            ProductHistory history = new ProductHistory();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    history.ProductId = reader.GetInt32(0);
                    history.ProductName = reader.GetString(1);
                    history.ProductSKU = reader.GetString(2);
                    history.ProductQuantity = reader.GetInt32(3);
                    history.ProductPrice = reader.GetDecimal(4);
                    history.Action = action.ToString();
                }

            }
            command.CommandText = $"INSERT INTO ProductHistories" +
                $"(ProductId, ProductName, ProductSKU, ProductQuantity, ProductPrice, Action, Timestamp)" +
                $" VALUES (" +
                            $"'{history.ProductId}'," +
                            $"'{history.ProductName}'," +
                            $"'{history.ProductSKU}'," +
                            $"'{history.ProductQuantity}'," +
                            $"'{history.ProductPrice}'," +
                            $"'{history.Action}'," +
                            $"'{history.Timestamp}')";
            command.ExecuteReader();
            return 0;
        }


        public enum actionType
        {
            updatePrice,
            updateQuantity,
            updateRestock,
            delete,
            insert
        }
    }
}
