using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorT
{
    class WordIterator : IEnumerable<string>
    {
        private string phrase;

        public WordIterator(string phrase)
        {
            this.phrase = phrase;
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (string s in phrase.Split())
            {
                yield return s;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string phrase = Console.ReadLine();
            foreach (string s in new WordIterator(phrase))
            {
                Console.WriteLine($"{s}\n");
            }
        }
    }
}
