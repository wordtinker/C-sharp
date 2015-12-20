using System;

namespace ConsoleInput
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input value: ");
            string input = Console.ReadLine();
            try
            {
                double inputValue = double.Parse(input);
                Console.WriteLine(inputValue);
            }
            catch (Exception)
            {
                Console.WriteLine("Try better.");
            }

            // Using tryParse is better
            Console.Write("Input value: ");
            input = Console.ReadLine();
            double iValue;
            if (double.TryParse(input, out iValue))
            {
                Console.WriteLine(iValue);
            }
            else
            {
                Console.WriteLine("Try better.");
            }
        }
    }
}
