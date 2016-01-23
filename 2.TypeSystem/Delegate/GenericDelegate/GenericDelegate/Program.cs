using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDelegate
{
    // This generic delegate can call any method
    // returning void and taking a single type parameter.
    public delegate void MyGenericDelegate<T>(T arg);

    class Program
    {
        static void Main(string[] args)
        {

            MyGenericDelegate<string> strTarget =
                // new MyGenericDelegate<string>(StringTarget);
                StringTarget;
            strTarget("Some string data.");

            MyGenericDelegate<int> intTarget =
                // new MyGenericDelegate<int>(IntTarget);
                IntTarget;
            intTarget(9);
            Console.ReadLine();
        }

        private static void IntTarget(int arg)
        {
            Console.WriteLine("++arg is: {0}", ++arg);
        }

        private static void StringTarget(string arg)
        {
            Console.WriteLine("arg in uppercase is: {0}", arg.ToUpper());
        }
    }
}
