using Microsoft.Data.Sqlite;
using store_stock_tracker.src.Cli.Utils;
using System.Numerics;
using System.Text;
using System.Xml;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
public static class Controller
{
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
                    "Update Stock", 
                    "Update Prices", 
                    "View Items Needing Restock", 
                    "Check Current Restock Thresholds", 
                    "Update Restock Thresholds", 
                    "Exit Program" };

                Console.WriteLine("Please select from the following by number: ");
                for (int i = 0; i < options.Length; i++) // Loop until every option displayed
                {
                    Console.WriteLine((i + 1) + ". " + options[i]);
                }
                Console.WriteLine();
                string choice = Console.ReadLine();
                // user chose to view current stock

                switch (choice) {
                    case "1":
                        Searcher.GetFullInventory();
                        break;
                    case "2":
                        Searcher.InitiateSearch();
                        break;
                    case "3":
                        StockUpdater.StockUpdate();
                        break;
                    case "4":
                        PriceUpdater.PriceUpdate();
                        break;
                    case "5":
                        //DataReader.GetRestockWarning();
                        break;
                    case "6":
                        //DataReader.GetRestockThreshold();
                        break;
                    case "7":
                        RestockUpdater.RestockUpdate();
                        break;
                    case "8":
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
}