using System;

namespace StaticGenerics
{

    class SomeGeneric<T>
    {
        // will be different for every closing T
        public static int Count;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string template = "Counting static: {0} for {1}";
            Console.WriteLine(template, ++SomeGeneric<int>.Count, typeof(int));
            Console.WriteLine(template, ++SomeGeneric<int>.Count, typeof(int));
            Console.WriteLine(template, ++SomeGeneric<string>.Count, typeof(string));
        }
    }
}
