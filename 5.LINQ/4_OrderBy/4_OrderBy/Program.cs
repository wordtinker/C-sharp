using System;
using System.Collections.Generic;
using System.Linq;

namespace _4_OrderBy
{
    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }
    class Program
    {
        static void OrderByElement()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords =
                from w in words
                orderby w
                select w;

            Console.WriteLine("The sorted list of words:");
            foreach (var w in sortedWords)
            {
                Console.WriteLine(w);
            }
        }
        static void OrderByAttribute()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords =
                from w in words
                orderby w.Length
                select w;

            Console.WriteLine("The sorted list of words (by length):");
            foreach (var w in sortedWords)
            {
                Console.WriteLine(w);
            }
        }
        static void OrderByComparer()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = words.OrderBy(a => a, new CaseInsensitiveComparer());

            Console.WriteLine("The sorted list of words (by comparer):");
            foreach (var w in sortedWords)
            {
                Console.WriteLine(w);
            }
        }
        static void OrderByDesc()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            var sortedDoubles =
                from d in doubles
                orderby d descending
                select d;

            Console.WriteLine("The doubles from highest to lowest:");
            foreach (var d in sortedDoubles)
            {
                Console.WriteLine(d);
            }
        }
        static void OrderByDescComparer()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = words.OrderByDescending(a => a, new CaseInsensitiveComparer());

            Console.WriteLine("The sorted list of words in descending order (by comparer):");
            foreach (var w in sortedWords)
            {
                Console.WriteLine(w);
            }
        }
        static void OrderByThenBy()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sortedDigits =
                from d in digits
                orderby d.Length, d
                select d;

            Console.WriteLine("Sorted digits:");
            foreach (var d in sortedDigits)
            {
                Console.WriteLine(d);
            }
        }
        static void ReverseOrder()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var reversedIDigits = (
                from d in digits
                where d[1] == 'i'
                select d)
                .Reverse();

            Console.WriteLine("A backwards list of the digits with a second character of 'i':");
            foreach (var d in reversedIDigits)
            {
                Console.WriteLine(d);
            }
        }
        static void Main(string[] args)
        {
            // Can order results by element
            OrderByElement();
            // or by attribute
            OrderByAttribute();
            // or by custom comparer
            OrderByComparer();
            // reorder in descending order
            OrderByDesc();
            // and even combine compaper and descending
            OrderByDescComparer();
            // Can order by several categories, compaper (.ThenBy) and descending could be applied as well
            OrderByThenBy();
            // Can reverse order
            ReverseOrder();
        }
    }
}
