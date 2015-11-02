using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public delegate void ChangeEventHandler();

    class EventsExample
    {
        public static event ChangeEventHandler windowChanged;
        public static void ChangeWindowSize(int height)
        {
            windowChanged += ShowEventMessage;
            windowChanged.Invoke();
        }
        public static void ShowEventMessage()
        {
            Console.WriteLine("Window resized");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            EventsExample.ChangeWindowSize(int.Parse(Console.ReadLine()));
        }
    }
}
