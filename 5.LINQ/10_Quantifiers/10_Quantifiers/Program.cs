using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Quantifiers
{
    class Program
    {
        static void AnySimple()
        {
            string[] words = { "believe", "relief", "receipt", "field" };

            bool iAfterE = words.Any(w => w.Contains("ei"));

            Console.WriteLine("There is a word that contains in the list that contains 'ei': {0}", iAfterE);
        }
        static void AllSimple()
        {
            int[] numbers = { 1, 11, 3, 19, 41, 65, 19 };

            bool onlyOdd = numbers.All(n => n % 2 == 1);

            Console.WriteLine("The list contains only odd numbers: {0}", onlyOdd);
        }
        static void Main(string[] args)
        {
            AnySimple();
            AllSimple();
        }
    }
}
