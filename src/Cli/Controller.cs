using store_stock_tracker.src.Cli.Utils;
public static class Controller
{
    /*
     * Temporary disable of Cli
    public static int RunCli()
    {
        while (true)
        {
            try
            {
                //Console.WriteLine("This is running");

                // Shows menu options
                string[] options = new[] {
                    "Show Full Table",
                    "Search Inventory",
                    "Process Sale",
                    "Process Restock",
                    "Update Prices",
                    "Update Restock Thresholds",
                    "Exit Program" };
                RestockWarning.GetRestockWarning();
                Console.WriteLine("\nPlease select from the following by number: ");
                for (int i = 0; i < options.Length; i++) // Loop until every option displayed
                {
                    Console.WriteLine((i + 1) + ". " + options[i]);
                }
                Console.WriteLine();
                string choice = Console.ReadLine();
                // user chose to view current stock

                switch (choice)
                {
                    case "1":
                        Searcher.CLIGetFullInventory();
                        break;
                    case "2":
                        Searcher.InitiateSearch();
                        break;
                    case "3":
                        StockUpdater.StockUpdate(choice);
                        break;
                    case "4":
                        StockUpdater.StockUpdate(choice);
                        break;
                    case "5":
                        PriceUpdater.PriceUpdate();
                        break;
                    case "6":
                        RestockUpdater.RestockUpdate();
                        break;
                    case "7":
                        Console.WriteLine("Goodbye");
                        return 0;
                    default:
                        Console.WriteLine("Selection was invalid. Enter the number associated with your selection.");
                        break;
                }
                Thread.Sleep(250);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
    */
}