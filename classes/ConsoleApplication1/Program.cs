using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Parent
    {
        public Parent()
        {
            Console.WriteLine("I'm a parent");
        }
    }

    class Calculator : Parent
    {
        public double rate = 0.05;

        public Calculator(string userSession)
        {
            Console.WriteLine("I'm a child");
            Console.Title = String.Format("{0}  {1}", userSession, DateTime.Now);
        }

        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Divide(double x, double y)
        {
            return x / y;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Session user:");
            string name = Console.ReadLine();
            var calc = new Calculator(name);
            Console.WriteLine("Enter numbers separated by a comma.");
            string input = Console.ReadLine();
            string[] s = input.Split(new char[] { ',' });
            Console.WriteLine("Sum is {0}", calc.Add(double.Parse(s[0]), double.Parse(s[1]))); // unsafe

            // check the shared variable
            Calculator[] arr = new Calculator[3] { new Calculator("1"), new Calculator("2"), new Calculator("3") };
            arr[0].rate = 0.1;
            foreach (var clc in arr)
            {
                Console.WriteLine("The rate is {0}",  clc.rate);
            }
            
        }
    }
}
