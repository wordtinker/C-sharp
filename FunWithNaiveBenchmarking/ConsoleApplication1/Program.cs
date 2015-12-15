using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Benchmark
    {
        static public void Run(string description, int iterations, Action func)
        {
            // Really naive approach to benchmarking
            // warm up 
            func();

            var watch = new Stopwatch();

            // clean up
            GC.Collect(); // Will put finalizers into separate thread
            GC.WaitForPendingFinalizers(); // They are on separate thread
            GC.Collect(); // Again clean up after finalizers

            watch.Start();
            for (int i = 0; i < iterations; i++)
                func();

            watch.Stop();
            Console.WriteLine(description);
            Console.WriteLine("Ran {0:N0} iterations in {1}ms\n", iterations,
                watch.Elapsed.TotalMilliseconds);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numTimes = 100000;

            // Some preliminary benchmarks
            var a = "foo bar foo";
            var b = "foo";
            Regex rx = new Regex("^" + b);

            Benchmark.Run("Ordinal string comparision.", numTimes, () => a.StartsWith(b, StringComparison.Ordinal));
            Benchmark.Run("Culture sensitive string comparision", numTimes, () => a.StartsWith(b));
            Benchmark.Run("Regex comparision", numTimes, () => RegexStartsWith(a, b));
            Benchmark.Run("Prebuild regex comparision", numTimes, () => rx.IsMatch(a));

            // Benchmarks
            string[] prefixes = {
                "a", "b", "c", "d", "e", "f", "a1", "b1", "c1", "d1", "e1", "f1" ,
                "a2", "b2", "c2", "d2", "e2", "f2", "a12", "b12", "c12", "d12", "e12", "f12" ,
                "aa", "ba", "ca", "da", "ea", "fa", "a1a", "b1a", "c1a", "d1a", "e1a", "f1a" 
            };
            string[] words =
            {
                "aword", "someword", "neword", "a1aword", "newword", "word"
            };

            Dictionary<string, string> dict = new Dictionary<string, string>();

            string pattern = string.Format("^({0})", string.Join("|", prefixes));
            rx = new Regex(pattern);

            Benchmark.Run("Original method", numTimes, () => ExpandStartsWith(words, prefixes, dict));
            Benchmark.Run("Original method with ord", numTimes, () => ExpandStartsWithOrd(words, prefixes, dict));
            Benchmark.Run("Regex method", numTimes, () => ExpandRegex(words, rx, dict));
        }

        static bool RegexStartsWith(string word, string prefix)
        {
            Regex rx = new Regex("^" + prefix);
            return rx.IsMatch(word);
        }

        static private bool IsExpandable(string word, string[] prefixes, Dictionary<string, string> dict)
        {
            foreach (string prefix in prefixes)
            {
                if (word.StartsWith(prefix) &&
                    dict.Keys.Contains(word.Substring(prefix.Length)))
                {
                    return true;
                }
            }
            return false;
        }

        static private void ExpandStartsWith(string[] words, string[] prefixes, Dictionary<string, string> dict)
        {
            foreach (string word in words)
            {
                IsExpandable(word, prefixes, dict);
            }
        }

        static private bool IsExpandableOrd(string word, string[] prefixes, Dictionary<string, string> dict)
        {
            foreach (string prefix in prefixes)
            {
                if (word.StartsWith(prefix, StringComparison.Ordinal) &&
                    dict.Keys.Contains(word.Substring(prefix.Length)))
                {
                    return true;
                }
            }
            return false;
        }

        static private void ExpandStartsWithOrd(string[] words, string[] prefixes, Dictionary<string, string> dict)
        {
            foreach (string word in words)
            {
                IsExpandableOrd(word, prefixes, dict);
            }
        }

        private static bool IsExpandableRegex(string word, Regex rx, Dictionary<string, string> dict)
        {
            string newword = rx.Replace(word, ""); // Not the same result!
            return dict.Keys.Contains(newword);
        }

        private static void ExpandRegex(string[] words, Regex rx, Dictionary<string, string> dict)
        {
            foreach (string word in words)
            {
                IsExpandableRegex(word, rx, dict);
            }
        }
    }
}
