using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            const string title = "Some string."; // wont even compile if you try to assign
            Console.Title = title;
            var someOtherTitle = title; // takes the type from title
            someOtherTitle += " !!!";
            Console.Title = someOtherTitle;
        }
    }
}
