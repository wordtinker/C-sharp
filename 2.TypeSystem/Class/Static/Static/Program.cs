using System;

namespace Static
{
    /// <summary>
    /// Static could be used for
    /// • Data of a class
    /// • Methods of a class
    /// • Properties of a class
    /// • A constructor
    /// • The entire class definition
    /// </summary>

    // A simple savings account class.
    class SavingsAccount
    {
        // Instance-level data.
        public double currBalance;
        // A static point of data.
        public static double currInterestRate;
        public SavingsAccount(double balance)
        {
            currBalance = balance;
        }
        // A static constructor!
        // Runs only once before the first usage
        // of static data and before instance constructors.
        static SavingsAccount()
        {
            Console.WriteLine("In static ctor!");
            currInterestRate = 0.04;
        }
        // Static members to get/set interest rate.
        public static void SetInterestRate(double newRate)
        { currInterestRate = newRate; }

        public static double GetInterestRate()
        { return currInterestRate; }
    }

    // Static classes can only
    // contain static members!
    static class TimeUtilClass
    {
        public static void PrintTime()
        { Console.WriteLine(DateTime.Now.ToShortTimeString()); }

        public static void PrintDate()
        { Console.WriteLine(DateTime.Today.ToShortDateString()); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Static Data *****\n");
            SavingsAccount s1 = new SavingsAccount(50);
            SavingsAccount s2 = new SavingsAccount(100);
            // Print the current interest rate.
            Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate());
            // Make new object, this does NOT 'reset' the interest rate.
            SavingsAccount s3 = new SavingsAccount(10000.75);
            Console.WriteLine("Interest Rate is: {0}", SavingsAccount.GetInterestRate());
            Console.ReadLine();

            // This is just fine.
            TimeUtilClass.PrintDate();
            TimeUtilClass.PrintTime();
        }
    }
}
