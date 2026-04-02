using store_stock_tracker.src.Tools;
using System.Globalization;
using System.Text;
using store_stock_tracker.Models;
namespace store_stock_tracker.src.Cli.Utils
{
    public class Searcher
    {
        /*
         * Temporary disable of Cli
        public static void InitiateSearch()
        {
            string[] options = new string[] { "Name", "Sku", "Back" };
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
                    Console.WriteLine("Input product Name");
                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                    string name = myTI.ToTitleCase(Console.ReadLine());
                    CLISearchByName(name);
                    break;
                case "Sku":
                case "2":
                    Console.WriteLine("Input product Sku");
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
            Console.WriteLine("Name                             |Sku             |Quantity |   Price|       Supplier");
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> inventory = instance.SelectProducts("SELECT * FROM Products");
            foreach (Product p in inventory)
            {
                Console.WriteLine($"{p.Name,-32} |{p.Sku,-15} |{p.Quantity,8} | {p.Price,7} | {p.Supplier,15}");
            }
        }

        public static void CLISearchByName(string name)
        {
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> results = instance.SelectProducts($"SELECT * FROM Products WHERE Name = '{name}'");
            if (results.Count == 0)
            {
                Console.WriteLine("No product found. Please try again.");
                return;
            }

            Console.WriteLine("Name                           |Sku             |Quantity |   Price");
            foreach (Product p in results)
            {
                Console.WriteLine($"{p.Name,-30} |{p.Sku,-15} |{p.Quantity,8} | {p.Price,7}");
                string[] options = new string[] { "Process Order", "Process Restock", "Update Price", "Update Restock Threshold", "Back" };
                Console.WriteLine("Edit this Item? Select by number: ");
                for (int i = 0; i < options.Length; i++) // Loop until every option displayed
                {
                    Console.WriteLine((i + 1) + ". " + options[i]);
                }
                string choice = Console.ReadLine();
                var sku = ConvertNameToSku.NameToSku(p.Name);
                switch (choice)
                {
                    case "Process Order":
                    case "1":
                        StockUpdateSkipSearcher.StockUpdate(choice, sku.ToUpper());
                        break;
                    case "Process Restock":
                    case "2":
                        StockUpdateSkipSearcher.StockUpdate(choice, sku.ToUpper());
                        break;
                    case "Update Price":
                    case "3":
                        PriceUpdateSkipSearcher.PriceUpdate(sku.ToUpper());
                        break;
                    case "Update Restock Threshold":
                    case "4":
                        RestockUpdateSkipSearcher.RestockUpdate(sku.ToUpper());
                        break;
                    case "Back":
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Selection was invalid. Enter the number associated with your selection.");
                        break;
                }
            }
        }

        public static void CLISearchBySKU(string sku)
        {
            InventoryAccessor instance = InventoryAccessor.GetInstance();
            List<Product> results = instance.SelectProducts($"SELECT * FROM Products WHERE Sku = '{sku.ToUpper()}'");
            if (results.Count == 0)
            {
                Console.WriteLine("No product found. Please try again.");
                return;
            }

            Console.WriteLine("Name                           |Sku             |Quantity |   Price");
            foreach (Product p in results)
            {
                Console.WriteLine($"{p.Name,-30} |{p.Sku,-15} |{p.Quantity,8} | {p.Price,7}");
                string[] options = new string[] { "Process Order", "Process Restock", "Update Price", "Update Restock Threshold", "Back" };
                Console.WriteLine("Edit this Item? Select by number: ");
                for (int i = 0; i < options.Length; i++) // Loop until every option displayed
                {
                    Console.WriteLine((i + 1) + ". " + options[i]);
                }
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "Process Order":
                    case "1":
                        StockUpdateSkipSearcher.StockUpdate(choice, sku.ToUpper());
                        break;
                    case "Process Restock":
                    case "2":
                        StockUpdateSkipSearcher.StockUpdate(choice, sku.ToUpper());
                        break;
                    case "Update Price":
                    case "3":
                        PriceUpdateSkipSearcher.PriceUpdate(sku.ToUpper());
                        break;
                    case "Update Restock Threshold":
                    case "4":
                        RestockUpdateSkipSearcher.RestockUpdate(sku.ToUpper());
                        break;
                    case "Back":
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Selection was invalid. Enter the number associated with your selection.");
                        break;
                }
            }
        }
        */
    }
}
