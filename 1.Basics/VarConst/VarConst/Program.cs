using System;

namespace VarConst
{
    class MyMathClass
    {
        public const double PI = 3.14; // value is known at declaration time
        public readonly double SuperPI; 

        public MyMathClass()
        {
            SuperPI = PI; // readonly value can be set in constructor
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const string title = "Some string."; // wont even compile if you try to assign
            Console.Title = title;
            var someOtherTitle = title; // takes the type from title
            someOtherTitle += " !!!";
            Console.Title = someOtherTitle;
            Console.WriteLine("{0}", MyMathClass.PI); // public const in implicitly static

        }
    }
}
