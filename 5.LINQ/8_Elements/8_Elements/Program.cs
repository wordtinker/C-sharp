using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Elements
{
    class Program
    {
        static void First()
        {
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            string startsWithO = strings.First();

            Console.WriteLine("First element is : {0}", startsWithO);
        }
        static void FirstWithCondition()
        {
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            string startsWithO = strings.First(s => s[0] == 'o');

            Console.WriteLine("A string starting with 'o': {0}", startsWithO);
        }
        static void Default()
        {
            int[] numbers = { };

            int firstNumOrDefault = numbers.FirstOrDefault();

            Console.WriteLine(firstNumOrDefault);
        }
        static void ElementAt()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int fourthLowNum = (
                from n in numbers
                where n > 5
                select n)
                .ElementAt(1);  // second number is index 1 because sequences use 0-based indexing 

            Console.WriteLine("Second number > 5: {0}", fourthLowNum);
        }
        static void Main(string[] args)
        {
            // Takes only first element
            First();
            // Takes the first matching element
            FirstWithCondition();
            // Takes first element. returns default if there is none
            // Could be used with condition too
            Default();
            // Takes element at specified position
            ElementAt();
        }
    }
}
