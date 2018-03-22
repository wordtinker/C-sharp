using LanguageExt;
using static LanguageExt.Prelude;
using System;
using System.Collections.Generic;

namespace testtryoption
{
    class Program
    {
        static string Get(string s)
        {
            Console.WriteLine($"Getting {s}");
            return s;
        }

        static IEnumerable<string> GetItems()
        {

            yield return Get("One");
            yield return Get("Two");
        }
        static IEnumerable<string> GetItemsTwo()
        {
            yield return Get("a");
            yield return Get("b");
        }

        static void Do()
        {
            foreach (var a in GetItems())
            {
                foreach (var b in GetItemsTwo())
                {
                    Console.WriteLine($"{a} -- {b}");
                }
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Do();
            // Notice difference of function eval here
            // between Lst and Seq
            Do2();
            Do3();
        }
        static Lst<Func<string>> GetLst()
        {
            return List<Func<string>>(() => Get("One"), () => Get("Two"));
        }
        static Lst<Func<string>> GetLstTwo()
        {
            return List<Func<string>>(() => Get("a"), () => Get("b"));
        }
        static Seq<Func<string>> GetSeq()
        {
            return Seq(GetLst());
        }
        static Seq<Func<string>> GetSeqTwo()
        {
            return Seq(GetLstTwo());
        }
        static void Do2()
        {
            var x =
            from a in GetSeq().Map(f => f.Invoke())
            from b in GetSeqTwo().Map(f => f.Invoke())
            select $"{a} -- {b}";
            x.Iter(Console.WriteLine);
            Console.WriteLine();
        }
        static void Do3()
        {
            var x =
            from a in GetLst().Map(f => f.Invoke())
            from b in GetLstTwo().Map(f => f.Invoke())
            select $"{a} -- {b}";
            x.Iter(Console.WriteLine);
        }
    }
}
