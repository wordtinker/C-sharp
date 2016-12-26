using System;

namespace ActionAndFuncDelegates
{
    class Program
    {
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Set color of console text.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;
            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }
            // Restore color.
            Console.ForegroundColor = previous;
        }

        // Target for the Func<> delegate.
        static int Add(int x, int y)
        {
            return x + y;
        }

        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Action and Func *****");
            // Use the Action<> delegate to point to DisplayMessage.
            Action<string, ConsoleColor, int> actionTarget = DisplayMessage;
            actionTarget("Action Message!", ConsoleColor.Yellow, 5);
            Console.ReadLine();

            // The last <T> is return Type
            Func<int, int, int> funcTarget = Add;
            Console.WriteLine("40 + 40 = {0}", funcTarget(40, 40));
            Func<int, int, string> funcTarget2 = SumToString;
            Console.WriteLine(funcTarget2(90, 300));

            // Predicate<T> delegate that returns bool
            DateTime[] dates =
            {
                new DateTime(2016, 12, 1),
                new DateTime(2016, 6, 1),
                new DateTime(2016, 11, 1)
            };
            Predicate<DateTime> searchCriteria = delegate (DateTime date) { return date.Month == 11; };
            // This method takes Predicate as second parameter
            DateTime dateInNovember = Array.Find(dates, searchCriteria);
            Console.WriteLine(dateInNovember);

            // Comparison delegate is used to sort or order the data inside a collection.
            // It takes two parameters as generic input type and return type should always be int.
            Comparison<DateTime> sortCriteria =
                delegate (DateTime date1, DateTime date2) { return date1.CompareTo(date2); };
            Array.Sort(dates, sortCriteria);
            Console.WriteLine("Sorting...");
            foreach (DateTime d in dates)
                Console.WriteLine(d);

            // Converter<TIn, TOut>
            Converter<DateTime, string> convertCriteria =
                delegate (DateTime date) { return $"Date is {date}"; };
            string[] strArr = Array.ConvertAll(dates, convertCriteria);
            foreach (string s in strArr)
            {
                Console.WriteLine(s);
            }
        }
    }
}
