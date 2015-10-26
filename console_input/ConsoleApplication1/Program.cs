using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
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
            }
        }
    }
}