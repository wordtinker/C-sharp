using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static int GetTurns()
        {
            int numTurns;

            while (true)
            {
                Console.WriteLine("How many turns?");
                if(int.TryParse(Console.ReadLine(), out numTurns))
                {
                    break;
                }
            }

            return numTurns;
        }

        static void Main()
        {
            var numTurns = GetTurns();
            int loopCounter = 1;
            string s = "";

            while (loopCounter <= numTurns)
            {
                s += Console.ReadLine();
                loopCounter += 1;
                //for (int i = 0; i < s.Length; i++)
                //{
                //    string subsrting = s.Substring(i, 1);
                //    Console.WriteLine(subsrting);
                //}
                foreach (var c in s)
                {
                    Console.WriteLine("The char is {0}", c);
                }
            }

            Console.WriteLine("You've entered {0} characters.", s.Length);
            Console.WriteLine("Avarage is {0}", (double)s.Length / numTurns);


            if (s.Length > 10)
            {
                Console.WriteLine("Very long string");
            }
            else
            {
                Console.WriteLine("The string is {0} chars long.", s.Length);
            }
        }
    }
}
