using static System.Console;
using static LanguageExt.Prelude;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LINQOverloads
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter first integer.");
            string s1 = ReadLine();
            WriteLine("Enter second integer.");
            string s2 = ReadLine();

            // Select and SelectMany are overloaded for usage with Option<A>
            var result = from a in parseInt(s1)
                         where a > 0
                         let aa = a * a
                         from b in parseInt(s2)
                         let bb = b * b
                         select aa + bb;
            WriteLine(result.Match(
                Some: r => $"{s1} * {s1} + {s2} * {s2} = {r}",
                None: () => "Please enter 2 valid integers"
                ));
        }
    }
}
