using System;
using System.Collections;

namespace FlowControl
{
    class Circle
    {
        public int Radius { get; set; }
    }
    class Rectangle
    {
        public int Height { get; set; }
        public int Length { get; set; }
    }
    class Program
    {
        static int GetTurns()
        {
            int numTurns;

            // while loop
            while (true)
            {
                Console.WriteLine("How many turns?");
                if (int.TryParse(Console.ReadLine(), out numTurns))
                {
                    break;
                }
            }

            return numTurns;
        }
        static void TestSwitch(int length)
        {
            switch (length)
            {
                case 0:
                    Console.WriteLine("Empty line");
                    break; // NB
                case 1:
                    Console.WriteLine("Exactly one char");
                    break;
                default:
                    break;
            }
        }
        static void TestSwitchPostSeven(object shape)
        {
            // Since C#7.0
            // You can switch on any type (not just primitive types)
            // Patterns can be used in case clauses
            // Case clauses can have additional conditions on them
            switch (shape)
            {
                // now order matters, the first will be matched
                case Circle c:
                    Console.WriteLine($"circle with radius {c.Radius}");
                    break;
                case Rectangle s when (s.Length == s.Height):
                    Console.WriteLine($"{s.Length} x {s.Height} square");
                    break;
                case Rectangle r:
                    Console.WriteLine($"{r.Length} x {r.Height} rectangle");
                    break;
                default: // will be evaluated last
                    Console.WriteLine("<unknown shape>");
                    break;
                case null:
                    throw new ArgumentNullException(nameof(shape));
            }
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
                // for loop
                foreach (var c in s)
                {
                    Console.WriteLine("The char is {0}", c);
                }
            }

            Console.WriteLine("You've entered {0} characters.", s.Length);
            Console.WriteLine("Avarage is {0}", (double)s.Length / numTurns);

            // Simple branching
            if (s.Length > 10)
            {
                Console.WriteLine("Very long string");
            }
            else
            {
                Console.WriteLine("The string is {0} chars long.", s.Length);
            }
            TestSwitch(s.Length);
            ArrayList aList = new ArrayList
            {
                new Circle { Radius = 7 },
                new Rectangle {Height = 5, Length = 7},
                new Rectangle {Height = 7, Length = 7},
                7,
                "seven"
            };
            foreach (object item in aList)
            {
                TestSwitchPostSeven(item);
            }
        }
    }
}
