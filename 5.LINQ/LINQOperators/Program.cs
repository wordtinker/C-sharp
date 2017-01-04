using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQOperators
{
    static class Utils
    {
        public static void Print<T>(this IEnumerable<T> enumerable, string message)
        {
            Console.WriteLine(message);
            foreach (T element in enumerable)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // I Filtering
            // IEnumerable<TSource> → IEnumerable<TSource>
            // WHERE
            string[] names = { "Tom", "Dick", "Harry","Jay", "Mary", "Jay" };
            var queryEndsWith = from n in names
                                where n.EndsWith("y")
                                select n;
            queryEndsWith.Print("Ends with y:");
            // Indexed filtering with WHERE
            // i is enumerated position
            names.Where((n, i) => i % 2 == 0).Print("Skip every second name");
            // .Select ((s,i) also works
            // TAKE emits first n elements
            names.Take(2).Print("First two names:");
            // SKIP discards first n elements
            names.Skip(2).Take(2).Print("2 names after previous two:");
            // TAKEWHILE
            names.TakeWhile(n => n.Length <= 4).Print("Short names before long one:");
            // SKIPWHILE
            names.SkipWhile(n => n.Length <= 4).Print("Drop short names before long one:");
            // DISTINCT
            names.Distinct().Print("Only unique names:");

            // II Projecting
            // IEnumerable<TSource> → IEnumerable<TResult>
            DirectoryInfo[] dirs = new DirectoryInfo(@"D:\PycharmProjects").GetDirectories();
            // nested subquery
            var query = from d in dirs
                        where (d.Attributes & FileAttributes.System) == 0
                        select new
                        {
                            DirectoryName = d.FullName,
                            Created = d.CreationTime,
                            Files = from f in d.GetFiles()
                                    where (f.Attributes & FileAttributes.Hidden) == 0
                                    select new { FileName = f.Name, f.Length, }
                        };
            foreach (var dirFiles in query)
            {
                Console.WriteLine("Directory: {0}", dirFiles.DirectoryName);
                foreach (var file in dirFiles.Files)
                    Console.WriteLine("  {0} Len:{1}",file.FileName, file.Length);
            }
            // select many projects n-size sequence into m-size sequence
            string[] fullNames = { "Anne Williams", "John Fred Smith", "Sue Green" };
            fullNames.SelectMany(name => name.Split()).Print("Split every name into parts");
            // the same
            (from fullname in fullNames
            from name in fullname.Split()
            select name).Print("Same splitted list");
            // Cartesian product
            int[] numbers = { 1, 2, 3 };
            string[] letters = { "a", "b" };
            (from n in numbers
             from l in letters
             select n.ToString() + l).Print("Cartesian");

            // III Joining see also Joins project
            string[] words = { "three", "five", "seven", "ignored" };
            IEnumerable<string> zip = numbers.Zip(words, (n, w) => n + "=" + w);
            zip.Print("Two were zipped into one:");

            // IV Ordering
            // OrderBy, OrderByDescending, ThenBy, and ThenByDescending, Reverse        }
    }
}
