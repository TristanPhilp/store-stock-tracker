

using System.Text;
using System.Xml;

public static class Controller
{
    public static int RunCli()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("This is running");

                // Shows menu options
                string[] options = new[] { "Check Current Stock", "Check Current Prices", "Exit Program" };
                int x = 0; // Start at the first option in array
                Console.WriteLine("Please select from the following: ", options);
                while (x < options.Length) // Loop until every option displayed
                {
                    Console.WriteLine(options[x]);
                    x += 1; // advance loop
                }
                string choice = Console.ReadLine();
                // User chose to exit
                if (choice == "Exit Program")
                {
                    Console.WriteLine("Goodbye!");
                    Thread.Sleep(250);
                }
                else if (choice == "Check Current Stock")
                {
                    Console.WriteLine("Showing Current Stock...");
                    Thread.Sleep(250);
                }
                else if (choice == "Check Current Prices")
                {
                    Console.WriteLine("Showing Prices...");
                    Thread.Sleep(250);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}