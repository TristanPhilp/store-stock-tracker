using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace store_stock_tracker.src.Cli.Utils
{
    internal class StockDisplay
    {
        public static string DisplayStock()
        {
            string[] ItemsName = new[] { "Item1", "Item2", "Item3" }; // Placeholder for item names, should be replaced with actual data retrieval
            int[] ItemsStock = new[] { 19, 7, 10 }; // Placeholder for item count, should be replaced with actual data retrieval



            int x = 0;
            StringBuilder Stock = new StringBuilder();
            while (x < ItemsName.Length) // Loop until we have processed every item.
            {
                Stock.Append(ItemsName[x]); // Add the current item name
                Stock.Append(": "); // Add formating
                Stock.Append(ItemsStock[x]); // Add the current item price
                Stock.Append('\n'); // Add a newline to end the line.
                x += 1; // Move to the next option.
            }
            return Stock.ToString();
        }

    }
}
