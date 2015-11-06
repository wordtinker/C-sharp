using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dates and times: ");
            DateTime dt = new DateTime(2015, 11, 5);
            Console.WriteLine("The day of {0} is {1}", dt.Date, dt.DayOfWeek);
            dt = dt.AddMonths(1);
            Console.WriteLine("The day of {0} is {1}", dt.Date, dt.DayOfWeek);

            TimeSpan ts = new TimeSpan(1, 3, 0);
            Console.WriteLine(ts);
        }
    }
}
