using System;

namespace Nullables
{
    class Program
    {
        static void Main(string[] args)
        {
            // Could be int or null
            int? nullableInt = 10;
            // Assume we get the value from DB.
            nullableInt = null;

            Console.WriteLine("The value is:{0}.", nullableInt.GetValueOrDefault());
            Console.WriteLine("The value is:{0}.", nullableInt ?? 100); // Return 100 if null
            Console.WriteLine("The value is:{0}.", nullableInt.GetValueOrDefault(100)); // Same
        }
    }
}
