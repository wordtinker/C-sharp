using System;

namespace StringFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Print to the stdout: {0}", 25); //like python "".format() method
            // C or c is used to format currency.
            Console.WriteLine("Use currency format: {0:C}", 25);
            // Used for fixed-point formatting.
            Console.WriteLine("Use 4 decimal places: {0:F4}", 25.123456);
            // Used for percent formatting.
            Console.WriteLine("Format with %: {0:P2}", 25.123456);
            // Cant also be used as:
            string userMessage = string.Format("100000 in hex is {0:x}", 100000);
            Console.WriteLine(userMessage);

        }
    }
}
