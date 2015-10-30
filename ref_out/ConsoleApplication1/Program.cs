using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Mix(ref int param)
        {
            param = 1000;
        }

        static void ChangeArray(int[] arr)
        {
            arr[0] = 1000;
            arr = new int[1] { 99999 };
            Console.WriteLine("Inside the method the first element is {0}", arr[0]);
        }

        static void ChangeWithRef(ref int[] arr)
        {
            arr[0] = 1000;
            arr = new int[1] { 99999 };
            Console.WriteLine("Inside the method the first element is {0}", arr[0]);
        }

        static void Main()
        {
            int x = 1;
            Console.WriteLine("Param is {0}", x);
            Mix(ref x);
            Console.WriteLine("Param is {0}", x);

            int[] xArray = { 1, 1, 1, 1, 1 };
            int[] anotherArray = xArray;
            Console.WriteLine("Before the change the first element is {0}", xArray[0]);
            ChangeArray(xArray);
            Console.WriteLine("After the method the first element is {0}", xArray[0]);
            Console.WriteLine("Array copy first element is {0}", anotherArray[0]);
            Console.WriteLine("Arrays are same: {0}", (xArray == anotherArray));
            Console.WriteLine();

            Console.WriteLine("Before the change the first element is {0}", xArray[0]);
            ChangeWithRef(ref xArray);
            Console.WriteLine("After the method the first element is {0}", xArray[0]);
            Console.WriteLine("Array copy first element is {0}", anotherArray[0]);
            Console.WriteLine("Arrays are same: {0}", (xArray == anotherArray));

        }
    }
}
