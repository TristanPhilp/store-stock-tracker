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
                string[] options = new[] { "List all SKU codes", "Check Current Stock", "Check Current Prices", "Update Stock", "Update Prices", "See Trending Items", "Exit Program" };
                int x = 0; // Start at the first option in array
                Console.WriteLine("Please select from the following: ", options);
                while (x < options.Length) // Loop until every option displayed
                {
                    Console.WriteLine(options[x]);
                    x += 1; // advance loop
                }
                Console.WriteLine();
                string choice = Console.ReadLine();
                // user chose to view current stock
                if (choice == "Check Current Stock")
                {
                    Console.WriteLine("Showing Current Stock...");
                    DataClass.GetStock();

                    Thread.Sleep(250);
                }
                // user chose to view current stock
                else if (choice == "Check Current Prices")
                {
                    Console.WriteLine("Showing Prices...");
                    DataClass.GetPrice();
                    Thread.Sleep(250);
                }
                // user chose to edit Stock
                else if (choice == "Update Stock")
                {
                    Console.WriteLine("Showing Current Stock...");
                    Console.WriteLine("Please select from the following: ");
                    Console.WriteLine(StockDisplay.DisplayStock());
                    // Console.ReadLine();
                    Thread.Sleep(250);
                }
                // user chose to edit Prices
                else if (choice == "Update Prices")
                {
                    Console.WriteLine("Showing Prices...");
                    Console.WriteLine("Please select from the following: ");
                    Console.WriteLine(PriceDisplay.DisplayPrices());
                    // Console.ReadLine();
                    Thread.Sleep(250);
                }
                else if (choice == "See Trending Items")
                {
                    Console.WriteLine("Currently Trending Items...");
                    // API call to get trending items would go here
                    Thread.Sleep(250);
                }
                // User chose to exit
                else if (choice == "Exit Program")
                {
                    Console.WriteLine("Goodbye");
                    Thread.Sleep(250);
                }
                else if (choice == "Test")
                {
                    Console.WriteLine("Using secret path");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}