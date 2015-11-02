using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Tablet tbl = new Tablet(450);
            tbl.Read();
            Console.WriteLine(tbl.CaseColor);
        }
    }
}
