using static System.Console;
using static System.Linq.Enumerable;
using System.Collections.Generic;
using System.Linq;

namespace Purity
{
    static class StringExt
    {
        // A pure function
        public static string ToSentenceCase(this string s)
            => s.ToUpper()[0] + s.ToLower().Substring(1);
    }
    class ListFormatter
    {
        int counter;
        // it's impure it mutates internal state
        // will fail as parallel
        string PrependCounter(string s) => $"{++counter}. {s}";

        public List<string> Format(List<string> list)
            =>
            list
            .Select(StringExt.ToSentenceCase)
            .Select(PrependCounter)
            .ToList();
    }
    static class PureListFormatter
    {        // Pure function        public static List<string> Format(List<string> list)
            =>
            list
            .Select(StringExt.ToSentenceCase)
            .Zip(Range(1, list.Count), (s, i) => $"{i}. {s}")
            .ToList();    }

    class Program
    {
        static void Main(string[] args)
        {
            // Function is pure if the output depends only on input arguments
            // cause no side effects

            // Strategies
            // 1. Isolate I/O operations
            // 2. Avoid mutating arguments

            var shoppingList = new List<string> { "coffee beans", "BANANAS", "Dates" };            new ListFormatter()
                .Format(shoppingList)
                .ForEach(WriteLine);            PureListFormatter.Format(shoppingList).ForEach(WriteLine);        }
    }
}
