using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace store_stock_tracker.src.Cli.Utils
{
    internal class PriceDisplay
    {
        public static string DisplayPrices()
        {
            string[] ItemsName = new[] { "Item1", "Item2", "Item3" }; // Placeholder for item names, should be replaced with actual data retrieval
            double[] ItemsPrice = new[] {15.99, 27.99, 100.99}; // Placeholder for item price, should be replaced with actual data retrieval



            int x = 0;
            StringBuilder Prices = new StringBuilder();
            while (x < ItemsName.Length) // Loop until we have processed every item.
            {
                Prices.Append(ItemsName[x]); // Add the current item name
                Prices.Append(": "); // Add formating
                Prices.Append(ItemsPrice[x]); // Add the current item price
                Prices.Append('\n'); // Add a newline to end the line.
                x += 1; // Move to the next option.
            }
            return Prices.ToString();
        }
    }
}
