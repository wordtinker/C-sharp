using System;
using System.Linq;

namespace _9_Generation
{
    class Program
    {
        static void Range()
        {
            var numbers =
            from n in Enumerable.Range(100, 50)

            select new { Number = n, OddEven = n % 2 == 1 ? "odd" : "even" };

            foreach (var n in numbers)
            {
                Console.WriteLine("The number {0} is {1}.", n.Number, n.OddEven);
            }
        }
        static void Repeat()
        {
            var numbers = Enumerable.Repeat(7, 10);

            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
        }
        static void Main(string[] args)
        {
            Range();
            Repeat();
        }
    }
}
