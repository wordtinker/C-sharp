using System;

namespace VarConst
{
    class Program
    {
        static void Main(string[] args)
        {
            const string title = "Some string."; // wont even compile if you try to assign
            Console.Title = title;
            var someOtherTitle = title; // takes the type from title
            someOtherTitle += " !!!";
            Console.Title = someOtherTitle;
        }
    }
}
