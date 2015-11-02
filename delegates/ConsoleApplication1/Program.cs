using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    delegate string CaseChanger(string str);
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
            string[] s1 = { "Hello", "World" };
            Console.WriteLine("{0} {1}", s1);
            StringUtils.Case(s1, StringUtils.Lower);
            Console.WriteLine("{0} {1}", s1);
            StringUtils.Case(s1, StringUtils.Upper);
            Console.WriteLine("{0} {1}", s1);
        }
    }
}
