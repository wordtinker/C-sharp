using System;
using System.Linq;

namespace _11_Aggregate
{
    class Program
    {
        static void Count()
        {
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };

            int uniqueFactors = factorsOf300.Distinct().Count();

            Console.WriteLine("There are {0} unique factors of 300.", uniqueFactors);
        }
        static void CountConditional()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int oddNumbers = numbers.Count(n => n % 2 == 1);

            Console.WriteLine("There are {0} odd numbers in the list.", oddNumbers);
        }
        static void Sum()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            double numSum = numbers.Sum();

            Console.WriteLine("The sum of the numbers is {0}.", numSum);
        }
        static void ProjectionSum()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            double totalChars = words.Sum(w => w.Length);

            Console.WriteLine("There are a total of {0} characters in these words.", totalChars);
        }
        static void Min()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int minNum = numbers.Min();

            Console.WriteLine("The minimum number is {0}.", minNum);
        }
        static void ProjectionMin()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            int shortestWord = words.Min(w => w.Length);

            Console.WriteLine("The shortest word is {0} characters long.", shortestWord);
        }
        static void Average()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            double averageNum = numbers.Average();

            Console.WriteLine("The average number is {0}.", averageNum);
        }
        static void ProjectionAverage()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            double averageLength = words.Average(w => w.Length);

            Console.WriteLine("The average word length is {0} characters.", averageLength);
        }
        static void Aggregate()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            double product = doubles.Aggregate((runningProduct, nextFactor) => runningProduct * nextFactor);
            Console.WriteLine("Total product of all numbers: {0}", product);
        }
        static void Main(string[] args)
        {
            // Simple count
            Count();
            // Count with condition
            CountConditional();
            // Simple Sum
            Sum();
            // Sum of the elements properties
            ProjectionSum();
            // Get the lowest element, same for Max
            Min();
            // Get the lowest element, using projection of that element
            ProjectionMin();
            // Simple average
            Average();
            // Average of the projection
            ProjectionAverage();
            // Aggregate 
            Aggregate();
        }
    }
}
