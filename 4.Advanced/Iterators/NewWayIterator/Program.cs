using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace NewWayIterator
{
    public class IterationSample : IEnumerable
    {
        object[] values;
        int startingPoint;

        public IterationSample(object[] values, int startingPoint)
        {
            this.values = values;
            this.startingPoint = startingPoint;
        }

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < values.Length; index++)
            {
                yield return values[(index + startingPoint) % values.Length];
            }
        }
    }

    class Program
    {
        // yield break demo
        static IEnumerable<int> CountWithTimeLimit(DateTime limit)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (DateTime.Now >= limit)
                {
                    yield break;
                }
                yield return i;
            }
        }

        static void Main(string[] args)
        {
            object[] values = { "a", "b", "c", "d", "e" };
            IterationSample collection = new IterationSample(values, 3);
            foreach (object x in collection)
            {
                Console.WriteLine(x);
            }

            DateTime stop = DateTime.Now.AddSeconds(2);
            foreach (int i in CountWithTimeLimit(stop))
            {
                Console.WriteLine("Received {0}", i);
                Thread.Sleep(300);
            }
        }
    }
}
