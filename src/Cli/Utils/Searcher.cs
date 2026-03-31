using System.Globalization;
using System.Text;

namespace store_stock_tracker.src.Cli.Utils
{
    public class Searcher
    {
        public static void InitiateSearch()
        {
            string[] options = new string[] { "Name", "SKU", "Back"};
            Console.WriteLine("Search by:?");
            for (int i = 0; i < options.Length; i++) // Loop until every option displayed
            {
                Console.WriteLine((i + 1) + ". " + options[i]);
            }

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "Name":
                case "1":
                    Console.WriteLine("Input product name");
                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                    string name = myTI.ToTitleCase(Console.ReadLine());
                    CLISearchByName(name);
                    break;
                case "SKU":
                case "2":
                    Console.WriteLine("Input product SKU");
                    string sku = Console.ReadLine();
                    CLISearchBySKU(sku);
                    break;
                case "Restock Warning":
                case "3":
                    return;
                default:
                    Console.WriteLine("Selection was invalid. Enter the number associated with your selection.");
                    break;
            }
        }


        public static void CLIGetFullInventory()
        {
            Console.WriteLine("Showing Table");
            Console.WriteLine("Name                             |SKU             |Quantity |   Price|       Supplier");
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> inventory = instance.SelectQuery("SELECT * FROM Products");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"{p.name,-32} |{p.sku,-15} |{p.quantity,8} | {p.price,7} | {p.supplier,15}");
            }
        }

        public static void CLISearchByName(string name)
        {
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> results = instance.SelectQuery($"SELECT * FROM Products WHERE Name = '{name}'");
            if(results.Count == 0)
            {
                Console.WriteLine("No product found. Please try again.");
                return;
            }

            Console.WriteLine("Name                           |SKU             |Quantity |   Price");
            foreach (Product p in results)
            {
                Console.WriteLine($"{p.name,-30} |{p.sku,-15} |{p.quantity,8} | {p.price,7}");
            }
        }

        public static void CLISearchBySKU(string sku)
        {
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> results = instance.SelectQuery($"SELECT * FROM Products WHERE SKU = '{sku.ToUpper()}'");
            if (results.Count == 0)
            {
                Console.WriteLine("No product found. Please try again.");
                return;
            }

            Console.WriteLine("Name                           |SKU             |Quantity |   Price");
            foreach (Product p in results)
            {
                Console.WriteLine($"{p.name,-30} |{p.sku,-15} |{p.quantity,8} | {p.price,7}");
            }
        }

        public static string APISearchBySKU(string sku)
        {
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> results = instance.SelectQuery($"SELECT * FROM Products WHERE SKU = '{sku.ToUpper()}'");
            StringBuilder returnResults = new StringBuilder();
            if (results.Count == 0)
            {
                return "No product found. Please try again.";
            }

            returnResults.Append("Name                           |SKU             |Quantity |   Price\n");
            foreach (Product p in results)
            {
                returnResults.Append($"{p.name,-30} |{p.sku,-15} |{p.quantity,8} | {p.price,7}\n");
            }
            return returnResults.ToString();
        }

        public static string APISearchByName(string name)
        {
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> results = instance.SelectQuery($"SELECT * FROM Products WHERE Name = '{name}'");
            StringBuilder returnResults = new StringBuilder();
            if (results.Count == 0)
            {
                return "No product found. Please try again.";
            }

            returnResults.Append("Name                           |SKU             |Quantity |   Price\n");
            foreach (Product p in results)
            {
                returnResults.Append($"{p.name,-30} |{p.sku,-15} |{p.quantity,8} | {p.price,7}\n");
            }
            return returnResults.ToString();
        }
    }
}
