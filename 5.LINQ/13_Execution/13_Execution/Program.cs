using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Execution
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sequence operators form first-class queries that 
            // are not executed until you enumerate over them. 

            int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int i = 0;
            var q =
                from n in numbers
                select ++i;

            // Note, the local variable 'i' is not incremented 
            // until each element is evaluated (as a side-effect) or consumed by ToList, etc.: 
            foreach (var v in q)
            {
                Console.WriteLine("v = {0}, i = {1}", v, i);
            }

            // Deferred execution lets us define a query once 
            // and then reuse it later after data changes. 
            var lowNumbers =
                from n in numbers
                where n <= 3
                select n;

            Console.WriteLine("First run numbers <= 3:");
            foreach (int n in lowNumbers)
            {
                Console.WriteLine(n);
            }

            for (int j = 0; j < 10; j++)
            {
                numbers[j] = -numbers[j];
            }

            // During this second run, the same query object, 
            // lowNumbers, will be iterating over the new state 
            // of numbers[], producing different results: 
            Console.WriteLine("Second run numbers <= 3:");
            foreach (int n in lowNumbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}
