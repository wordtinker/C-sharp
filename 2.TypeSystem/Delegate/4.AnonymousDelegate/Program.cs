using System;

namespace AnonymousDelegate
{
    public delegate int BinaryOp(int x, int y);

    public class SimpleMath
    {
        public static int Add(int x, int y) { return x + y; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Simple delegate
            BinaryOp c = SimpleMath.Add;
            Console.WriteLine("20 + 10 is {0}", c(20, 10));
            Console.WriteLine();

            // Anonymous delegate
            BinaryOp b = delegate (int x, int y) { return x + y;  };
            Console.WriteLine("30 + 10 is {0}", b(30, 10));
            // Anonymous  delegate that doesn’t depend on its parameter values
            BinaryOp d = delegate { return 10; };
            Console.WriteLine("10 is {0}", d(30, 10));
        }
    }
}
