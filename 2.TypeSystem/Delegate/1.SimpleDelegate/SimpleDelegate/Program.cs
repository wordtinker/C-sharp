using System;

namespace SimpleDelegate
{
    // A delegate maintains three important pieces of information:
    // 1 The address of the method on which it makes calls
    // 2 The parameters(if any) of this method
    // 3 The return type (if any) of this method

    // • Declare DELEGATE TYPE
    // This delegate can point to any method,
    // taking two integers and returning an integer.
    public delegate int BinaryOp(int x, int y);
    // Simple delegate to transform string into another string
    delegate string CaseChanger(string str);
    
    // This class contains methods BinaryOp will point to.
    public class SimpleMath
    {
        // •• the code to be executed in a method
        public static int Add(int x, int y)
        { return x + y; }

        public static int Subtract(int x, int y)
        { return x - y; }
    }
    
    class StringUtils
    {
        public static void Case(string[] arr, CaseChanger func)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = func(arr[i]);
            }
        }

        public static string Lower(string s) { return s.ToLower(); }
        public static string Upper(string s) { return s.ToUpper(); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Delegate Example *****\n");
            // Create a BinaryOp delegate object that
            // "points to" SimpleMath.Add().
            // ••• DELEGATE INSTANCE
            // This is NET 1.x style insantiation
            BinaryOp b = new BinaryOp(SimpleMath.Add);
            // •••• Invoke Add() method indirectly using delegate object.
            Console.WriteLine("10 + 10 is {0}", b.Invoke(10, 10));
            // Shorthand
            Console.WriteLine("10 + 10 is {0}", b(10, 10));
            Console.ReadLine();

            // NET 2.0 instantiation
            BinaryOp c = SimpleMath.Subtract;
            Console.WriteLine("20 - 10 is {0}", c(20, 10));
            Console.WriteLine();

            // Second example
            string[] s1 = { "Hello", "World" };
            Console.WriteLine("{0} {1}", s1);
            StringUtils.Case(s1, StringUtils.Lower);
            Console.WriteLine("{0} {1}", s1);
            StringUtils.Case(s1, StringUtils.Upper);
            Console.WriteLine("{0} {1}", s1);
        }
    }
}
