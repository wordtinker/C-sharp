using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Honesty
{
    enum Risk { Low, Medium, High }
    public class Age
    {
        private int Value { get; }

        public Age(int value)
        {
            if (!IsValid(value))
                throw new ArgumentException($"{value} is not a valid age");
            Value = value;
        }
        private static bool IsValid(int age)
            => 0 <= age && age < 120;
        // 
        public static bool operator <(Age l, Age r) => l.Value < r.Value;
        public static bool operator >(Age l, Age r) => l.Value > r.Value;
        // Reduce noise and comparison with integer now checks for validity
        public static bool operator <(Age l, int r) => l < new Age(r);
        public static bool operator >(Age l, int r) => l > new Age(r);
    }

    class Program
    {
        // Age -> Risk
        static Risk CalculateRiskProfile(Age age)
        {
            // You’ll have to write additional unit tests for the cases in which validation fails.
            // There are a few other areas of the application where an age is expected, so you’re probably
            // going to need the same validation in those places. This will cause some duplication.
            // FIXED
            // if (age < 0 || 120 <= age)
            //    throw new ArgumentException($"{age} is not a valid age");

            return (age < 60) ? Risk.Low : Risk.Medium;
            // You might hear functional programmers talk about honest or dishonest functions. An honest
            // function is simply one that does what it says on the tin; it honors its signature—always.
            // In summary, a function is honest if its behavior can be predicted by its signature: it returns a
            // value of the declared type; no throwing exceptions, and no null return values.
        }

        static void Main(string[] args)
        {
            Console.WriteLine(CalculateRiskProfile(new Age(59)));
        }
    }
}
