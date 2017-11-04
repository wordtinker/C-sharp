using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TakeAndSkip
{
    class Program
    {
        static void TakeThree()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var first3Numbers = numbers.Take(3);

            Console.WriteLine("First 3 numbers:");
            foreach (var n in first3Numbers)

            {
                Console.WriteLine(n);
            }
        }
        static void SkipFour()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var allButFirst4Numbers = numbers.Skip(4);

            Console.WriteLine("All but first 4 numbers:");
            foreach (var n in allButFirst4Numbers)
            {
                Console.WriteLine(n);
            }
        }
        static void NotUntilSix()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);

            Console.WriteLine("First numbers less than 6:");
            foreach (var n in firstNumbersLessThan6)
            {
                Console.WriteLine(n);
            }
        }
        static void NotUntilIndexed()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);

            Console.WriteLine("First numbers not less than their position:");
            foreach (var n in firstSmallNumbers)
            {
                Console.WriteLine(n);
            }
        }
        static void SkipUntil()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var allButFirst3Numbers = numbers.SkipWhile(n => n % 3 != 0);

            Console.WriteLine("All elements starting from first element divisible by 3:");

            foreach (var n in allButFirst3Numbers)
            {
                Console.WriteLine(n);
            }
        }
        static void Main(string[] args)
        {
            // Can take only first several items
            TakeThree();
            // Can skip several items
            SkipFour();
            // Can take as long as condition is met
            NotUntilSix();
            // Can do that with index
            NotUntilIndexed();
            // Can skip until condition is met
            SkipUntil();
        }
    }
}
