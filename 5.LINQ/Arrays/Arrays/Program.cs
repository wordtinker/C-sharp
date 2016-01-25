using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    class Program
    {
        static void QueryOverStrings()
        {
            string[] currentVideoGames = { "Morrowind",
                "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

            var subset = from g in currentVideoGames
                         where g.Contains(" ")
                         orderby g
                         select g;

            foreach (string s in subset)
            {
                Console.WriteLine("Item: {0}", s);
            }
        }

        static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // Print only items less than 10.
            var subset = from i in numbers
                                      where i < 10
                                      select i;
            foreach (int i in subset)
                Console.WriteLine("Item: {0}", i);
            Console.WriteLine();

            // Change data in array
            numbers[0] = 4;
            // LINQ has changed
            foreach (int i in subset)
                Console.WriteLine("Item: {0}", i);
        }
        static void Main(string[] args)
        {
            QueryOverStrings();
            QueryOverInts();
        }
    }
}
