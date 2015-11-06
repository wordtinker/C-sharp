using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int? i = 100; // make non-nullable type nullable
            i = null;
            i = i ?? + 100; // use ?? to use default value, not null
            Console.WriteLine(i);

            string s = "string"; // nullable
            s = null;

            int[] array = new int[] { 1, 2, 3 };  // nullable
            array = null;

        }
    }
}
