using System;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            // public class Tuple<T1>
            // public class Tuple<T1, T2>
            // public class Tuple<T1, T2, T3>
            // public class Tuple<T1, T2, T3, T4>
            // public class Tuple<T1, T2, T3, T4, T5>
            // public class Tuple<T1, T2, T3, T4, T5, T6>
            // public class Tuple<T1, T2, T3, T4, T5, T6, T7>
            // public class Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>
            // Handy for ret values

            // Creation
            Tuple<int, string> t = new Tuple<int, string>(123, "Hello");
            Tuple<int, string> t2 = Tuple.Create(123, "Hello");
            // Comparison and ToString are overloaded
            Console.WriteLine($"{t} == {t2}? : {t.Equals(t2)}");        }
    }
}
