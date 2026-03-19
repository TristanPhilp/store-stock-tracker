using System.Globalization;

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
                    SearchByName(name);
                    break;
                case "SKU":
                case "2":
                    Console.WriteLine("Input product SKU");
                    string sku = Console.ReadLine();
                    SearchBySKU(sku);
                    break;
                case "Restock Warning":
                case "3":
                    return;
                default:
                    Console.WriteLine("Selection was invalid. Enter the number associated with your selection.");
                    break;
            }
        }


        public static void GetFullInventory()
        {
            Console.WriteLine("Showing Table");
            Console.WriteLine("Name            |SKU             |Quantity |   Price|       Supplier");
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> inventory = instance.Query("SELECT * FROM Products");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"{p.name,-15} |{p.sku,-15} |{p.quantity,8} | {p.price,7} | {p.supplier,15}");
            }
        }

        public static void SearchByName(string name)
        {
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> results = instance.Query($"SELECT * FROM Products WHERE Name = '{name}'");
            if(results.Count == 0)
            {
                Console.WriteLine("No product found. Please try again.");
                return;
            }

            Console.WriteLine("Name            |SKU             |Quantity |   Price");
            foreach (Product p in results)
            {
                Console.WriteLine($"{p.name,-15} |{p.sku,-15} |{p.quantity,8} | {p.price,7}");
            }
        }

        public static void SearchBySKU(string sku)
        {
            ProductAccessor instance = ProductAccessor.GetInstance();
            List<Product> results = instance.Query($"SELECT * FROM Products WHERE SKU = '{sku.ToUpper()}'");
            if (results.Count == 0)
            {
                Console.WriteLine("No product found. Please try again.");
                return;
            }

            Console.WriteLine("Name            |SKU             |Quantity |   Price");
            foreach (Product p in results)
            {
                Console.WriteLine($"{p.name,-15} |{p.sku,-15} |{p.quantity,8} | {p.price,7}");
            }
        }
    }
}
