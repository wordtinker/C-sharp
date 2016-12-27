using System;
using System.Collections;

namespace OldWayIterator
{
    // using non-generic collection
    public class IterationSample : IEnumerable
    {
        class IterationSampleIterator : IEnumerator
        {
            // state
            IterationSample parent;
            int position;

            internal IterationSampleIterator(IterationSample parent)
            {
                this.parent = parent;
                position = -1;
            }

            public object Current
            {
                get
                {
                    if (position == -1 || position == parent.values.Length)
                    {
                        throw new InvalidOperationException();
                    }
                    int index = position + parent.startingPoint;
                    index = index % parent.values.Length;
                    return parent.values[index];
                }
            }

            public bool MoveNext()
            {
                if (position != parent.values.Length)
                {
                    position++;
                }
                return position < parent.values.Length;
            }

            public void Reset()
            {
                position = -1;
            }
        }

        object[] values;
        int startingPoint;

        public IterationSample(object[] values, int startingPoint)
        {
            this.values = values;
            this.startingPoint = startingPoint;
        }

        public IEnumerator GetEnumerator()
        {
            return new IterationSampleIterator(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            object[] values = { "a", "b", "c", "d", "e" };
            IterationSample collection = new IterationSample(values, 3);
            foreach (object x in collection)
            {
                Console.WriteLine(x);
            }
        }
    }
}
