using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Conversion
{
    class Program
    {
        static void ToArray()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };
            var sortedDoubles =
                from d in doubles
                orderby d descending
                select d;
            var doublesArray = sortedDoubles.ToArray();

            Console.WriteLine("Every other double from highest to lowest:");
            for (int d = 0; d < doublesArray.Length; d += 2)
            {
                Console.WriteLine(doublesArray[d]);
            }
        }
        static void ToList()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords =
                from w in words
                orderby w
                select w;
            var wordList = sortedWords.ToList();

            Console.WriteLine("The sorted word list:");
            foreach (var w in wordList)
            {
                Console.WriteLine(w);
            }
        }
        static void ToDic()
        {
            var scoreRecords = new[] { new {Name = "Alice", Score = 50},
                                new {Name = "Bob"  , Score = 40},
                                new {Name = "Cathy", Score = 45}
                            };

            var scoreRecordsDict = scoreRecords.ToDictionary(sr => sr.Name);

            Console.WriteLine("Bob's score: {0}", scoreRecordsDict["Bob"]);
        }
        static void OfType()
        {
            object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };

            var doubles = numbers.OfType<double>();

            Console.WriteLine("Numbers stored as doubles:");
            foreach (var d in doubles)
            {
                Console.WriteLine(d);
            }
        }
        static void Main(string[] args)
        {
            // immediately evaluate a sequence into an array.
            ToArray();
            // immediately evaluate a sequence into a list.
            ToList();
            // immediately evaluate a sequence and a related key expression into a dictionary.
            ToDic();
            // filter input sequence to return only elements of specified type
            OfType();
        }
    }
}
