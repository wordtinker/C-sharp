using System;

namespace StaticGenerics
{

    class ClassWithField<T>
    {
        // will be different for every closing T
        public static string field;
        public static void PrindField()
        {
            Console.WriteLine("field: {0} of T: {1}", field, typeof(T).Name);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ClassWithField<int>.field = "First";
            ClassWithField<string>.field = "Second";
            ClassWithField<DateTime>.field = "Third";

            ClassWithField<int>.PrindField();
            ClassWithField<string>.PrindField();
            ClassWithField<DateTime>.PrindField();
        }
    }
}
