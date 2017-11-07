using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQOperators
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
