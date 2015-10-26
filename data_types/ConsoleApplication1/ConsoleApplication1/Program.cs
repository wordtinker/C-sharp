using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            ushort dogCount;
            dogCount = 5;
            double lengthOfWood = 36.75;
            decimal money = 125.63M; // M is used for decimal
            Console.WriteLine("Mary has {0} dogs", dogCount);
            Console.WriteLine("The plank is {0} cm long", lengthOfWood);
            Console.WriteLine("John has a fortune of {0:C}", money);
            int x = 50;
            Console.WindowWidth = x;
            Console.ReadKey();
            x = 100;
            Console.WindowWidth = x;
            Console.ReadKey();

            int w = Console.WindowWidth;
            int h = Console.WindowHeight;

            Console.WriteLine("Perimeter is {0}", 2 * w + 2 * h);
            Console.WriteLine("H goes into W {0} times.", w / h);
            Console.WriteLine("H goes into W {0} times.", (double)h / (double)w);
        }
    }
}
