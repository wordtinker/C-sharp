using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{

    class ActionSample
    {
        public static void Print(string s)
        {
            Console.WriteLine(s);
        }

        public static void Reverse(string s)
        {
            char[] a = s.ToCharArray();
            Array.Reverse(a);
            Print(new string(a));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Action<string> PrintIt = ActionSample.Print; // shorthand delegate with no return value
            Action<string> ReverseIt = ActionSample.Reverse;
            List<string> myList = new List<string>();
            myList.Add("One");
            myList.Add("Two");
            myList.Add("Three");
            myList.ForEach(PrintIt + ReverseIt);
        }
    }
}
