using System;

namespace Nullables
{
    class MyObject
    {
        public class InnerObject
        {
            public int X { get; set; }
        }

        public InnerObject IO;
    }
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
            // Init an object
            MyObject mo = new MyObject();
            // Return value of X if innerobject is not null, null otherwise
            Console.WriteLine("The value of inner object is available: {0}", mo.IO?.X != null);
        }
    }
}
