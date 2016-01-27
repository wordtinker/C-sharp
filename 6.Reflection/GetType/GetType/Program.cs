using System;

namespace GetType
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 32;
            Type t = x.GetType(); // need instance
            Console.WriteLine(t);

            Console.WriteLine(typeof(int)); // need class

            Type t2 = Type.GetType("System.Int32", false);
            // "CarLibrary.JamesBondCar+SpyOptions" for nested types
            Console.WriteLine(t2);
        }
    }
}
