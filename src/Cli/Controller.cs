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
                string[] options = new[] {"Show Full Table", "Update Stock", "Update Prices", "View Items Needing Restock", "Check Current Restock Thresholds", "Update Restock Thresholds", "Exit Program" };
                int x = 0; // Start at the first option in array
                Console.WriteLine("Please select from the following by number: ");
                while (x < options.Length) // Loop until every option displayed
                {
                    Console.WriteLine((x + 1) + ". " + options[x]);
                    x += 1; // advance loop
                }
                Console.WriteLine();
                string choice = Console.ReadLine();
                // user chose to view current stock

                switch (choice) {
                    case "1":
                        Console.WriteLine("Showing Table");
                        DataClass.GetFullTable();
                        break;
                    case "2":
                        Console.WriteLine("Showing Current Stock...");
                        Console.WriteLine("Please select from the following SKU: ");
                        StockUpdater.StockUpdate();
                        break;
                    case "3":
                        Console.WriteLine("Showing Prices...");
                        Console.WriteLine("Please select from the following SKU: ");
                        PriceUpdater.PriceUpdate();
                        Thread.Sleep(250);
                        break;
                    case "4":
                        Console.WriteLine("Showing Items With Low Stock...");
                        DataClass.GetRestockWarning();
                        break;
                    case "5":
                        Console.WriteLine("Current Restock Warnings...");
                        DataClass.GetRestockThreshold();
                        break;
                    case "6":
                        Console.WriteLine("Showing Restock Thresholds...");
                        Console.WriteLine("Please select from the following SKU: ");
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
}