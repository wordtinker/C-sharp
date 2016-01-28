﻿using System;
using System.Threading;

namespace TimerApp
{
    class Program
    {
        static void PrintTime(object state)
        {
            Console.WriteLine("Time is: {0} :: {1}",
            DateTime.Now.ToLongTimeString(),
            state.ToString());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Working with Timer type *****\n");
            // Create the delegate for the Timer type.
            TimerCallback timeCB = new TimerCallback(PrintTime);
            // Establish timer settings.
            Timer t = new Timer(
            timeCB, // The TimerCallback delegate object.
            "Hello!", // Any info to pass into the called method (null for no info).
            0, // Amount of time to wait before starting (in milliseconds).
            1000); // Interval of time between calls (in milliseconds).
            Console.WriteLine("Hit key to terminate...");
            Console.ReadLine();
        }
    }
}
