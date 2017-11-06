using System;
using System.Collections.Generic;
using System.Linq;

namespace _5_Group
{
    public class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return getCanonicalString(x) == getCanonicalString(y);
        }

        public int GetHashCode(string obj)
        {
            return getCanonicalString(obj).GetHashCode();
        }

        private string getCanonicalString(string word)
        {
            char[] wordChars = word.ToCharArray();
            Array.Sort<char>(wordChars);
            return new string(wordChars);
        }
    }
    class Program
    {
        static void Grouping1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numberGroups =
                from n in numbers
                group n by n % 5 into g
                // g.Key is n % 5, g is n grouped under n % 5 
                select new { Remainder = g.Key, Numbers = g };

            foreach (var g in numberGroups)
            {
                Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder);
                foreach (var n in g.Numbers)
                {
                    Console.WriteLine(n);
                }
            }
        }
        static void Grouping2()
        {
            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

            var wordGroups =
                from w in words
                group w by w[0] into g
                select new { FirstLetter = g.Key, Words = g };

            foreach (var g in wordGroups)
            {
                Console.WriteLine("Words that start with the letter '{0}':", g.FirstLetter);
                foreach (var w in g.Words)
                {
                    Console.WriteLine(w);
                }
            }
        }
        static void GroupingWithComparer()
        {
            string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            var orderGroups = anagrams.GroupBy(w => w.Trim(), new AnagramEqualityComparer());
            foreach (var item in orderGroups)
            {
                Console.WriteLine("...");
                foreach (var w in item)
                {
                    Console.WriteLine(w);
                }
            }
        }
        static void GroupingWithComparerAndMap()
        {
            string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            var orderGroups = anagrams.GroupBy(
                        w => w.Trim(),
                        a => a.ToUpper(),
                        new AnagramEqualityComparer()
                        );
            foreach (var item in orderGroups)
            {
                Console.WriteLine("...");
                foreach (var w in item)
                {
                    Console.WriteLine(w);
                }
            }
        }
        static void Main(string[] args)
        {
            Grouping1();
            Grouping2();
            GroupingWithComparer();
            // Project every element with internal .select
            GroupingWithComparerAndMap();
        }
    }
}
