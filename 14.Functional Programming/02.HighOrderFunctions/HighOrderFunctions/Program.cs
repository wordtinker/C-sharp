using System;
using System.Linq;
using static System.Linq.Enumerable;

namespace HighOrderFunctions
{
    static class Extensions
    {
        public static Func<T2, T1, R> SwapArgs<T1, T2, R>(this Func<T1, T2, R> f)
            => (t2, t1) => f(t1, t2);

    }
    class Program
    {
        static void Main(string[] args)
        {
            //HOFs are functions that take other functions as inputs or return a function as output, or both.
            // I function that apply given function iterativley or
            // conditionally
            // II adapter functions
            Func<int, int, int> divide = (x, y) => x / y;
            Console.WriteLine(divide(10, 2));
            var inversed = divide.SwapArgs();
            Console.WriteLine(inversed(2, 10));
            // III Functions that create other functions
            Func<int, bool> isMod(int n) => i => i % n == 0;
            Console.WriteLine(Range(1, 20).Where(isMod(2)));
            Console.WriteLine(Range(1, 20).Where(isMod(3)));
        }
    }
}
