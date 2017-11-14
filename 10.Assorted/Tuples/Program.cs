using System;

namespace Tuples
{
    class Program
    {
        static Tuple<int, int> GetMultipleValues()
        {
            return Tuple.Create(1, 2);
        }

        static (int, int) GetMultipleValues7()
        {
            return (1, 2);
        }
        // Now with named elements
        static (int first, int second) GetMultipleValuesWithNames()
        {
            // may return as named literals
            return (first: 1, second: 2);
        }

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

            // Pre C#7.0
            // Creation
            Tuple<int, string> t = new Tuple<int, string>(123, "Hello");
            Tuple<int, string> t2 = Tuple.Create(123, "Hello");
            // Comparison and ToString are overloaded
            Console.WriteLine($"{t} == {t2}? : {t.Equals(t2)}");
            // Post C#7.0
            // Target 4.7 or use Nuget: "System.ValueTuple"
            var t3 = GetMultipleValues7();
            Console.WriteLine($"{t3.Item1} -- {t3.Item2}");
            // Even better with names
            var t4 = GetMultipleValuesWithNames();
            Console.WriteLine($"{t4.first} -- {t4.second}");
            // Deconstructing tuples
            // can be used with pre-declared variables
            (int first, _) = GetMultipleValues7();
            Console.WriteLine(first);
            // Any class can implement public void Deconstruct(out T1 x1, ..., out Tn xn) { ... }
        }
    }
}
