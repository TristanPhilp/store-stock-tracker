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
                string[] options = new[] { "List all SKU codes", "Check Current Stock", "Check Current Prices", "Update Stock", "Update Prices", "View Items Needing Restock", "Check Current Restock Thresholds", "Update Restock Thresholds", "Exit Program" };
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
                if (choice == "1")
                {
                    Console.WriteLine("Showing Current Stock...");
                    DataClass.GetSKU();
                    Thread.Sleep(250);
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Showing Current Stock...");
                    DataClass.GetStock();
                    Thread.Sleep(250);
                }
                // user chose to view current stock
                else if (choice == "3")
                {
                    Console.WriteLine("Showing Prices...");
                    DataClass.GetPrice();
                    Thread.Sleep(250);
                }
                // user chose to edit Stock
                else if (choice == "4")
                {
                    Console.WriteLine("Showing Current Stock...");
                    Console.WriteLine("Please select from the following SKU: ");
                    StockUpdater.StockUpdate();
                    Thread.Sleep(250);
                }
                // user chose to edit Prices
                else if (choice == "5")
                {
                    Console.WriteLine("Showing Prices...");
                    Console.WriteLine("Please select from the following SKU: ");
                    PriceUpdater.PriceUpdate(); 
                    Thread.Sleep(250);
                }
                else if (choice == "6")
                {
                    Console.WriteLine("Showing Items With Low Stock...");
                    DataClass.GetRestockWarning();
                    Thread.Sleep(250);
                }
                else if (choice == "7")
                {
                    Console.WriteLine("Current Restock Warnings...");
                    DataClass.GetRestockThreshold();
                    Thread.Sleep(250);
                }
                else if (choice == "8")
                {
                    Console.WriteLine("Showing Restock Thresholds...");
                    Console.WriteLine("Please select from the following SKU: ");
                    RestockUpdater.RestockUpdate();
                    Thread.Sleep(250);
                }
                // User chose to exit
                else if (choice == "9")
                {
                    Console.WriteLine("Goodbye");
                    Thread.Sleep(250);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}