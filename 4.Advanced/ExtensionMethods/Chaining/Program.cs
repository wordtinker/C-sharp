using System;
using System.Linq;

namespace Chaining
{
    class Program
    {
        static void Main(string[] args)
        {
            // var is unknown till compile time
            var collection = Enumerable.Range(-5, 11)
                .Where(x => x % 2 != 0)
                .Select(x => new { Original = x, Square = x * x })
                .OrderBy(x => x.Square) // watch for power of generics with extension methods
                .ThenBy(x => x.Original);

            foreach (var element in collection)
            {
                Console.WriteLine("sqrt({0})={1}",
                element.Original,
                element.Square);
            }
        }
    }
}
