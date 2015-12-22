using System;

namespace StringFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Print to the stdout: {0}", 25); //like python "".format() method
            Console.WriteLine("Use currency format: {0:C}", 25);
            Console.WriteLine("Use 4 decimal places: {0:F4}", 25.123456);
            Console.WriteLine("Format with %: {0:P2}", 25.123456);
        }
    }
}
