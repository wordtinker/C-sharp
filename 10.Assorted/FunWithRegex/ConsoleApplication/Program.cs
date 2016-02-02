using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "go";
            string endOfWord = "$";
            Regex re = new Regex(endOfWord);
            // Add ending
            string newWord = re.Replace(word, "ing");
            Console.WriteLine(string.Format("{0}->{1}", word, newWord));

            string endsWithO = "o$";
            re = new Regex(endsWithO);
            // Replace O With "reat"
            newWord = re.Replace(word, "reat");
            Console.WriteLine(string.Format("{0}->{1}", word, newWord));
            // Strip the letter
            newWord = re.Replace(word, "");
            Console.WriteLine(string.Format("{0}->{1}", word, newWord));
            // Keep the word untouched
            newWord = re.Replace(word, "$&");
            Console.WriteLine(string.Format("{0}->{1}", word, newWord));

            // Starts ^ with any characters .+ Ends not with ab
            string notAB = "^.+[^ab]$";
            re = new Regex(notAB);
            // Add ending
            newWord = re.Replace(word, "$&ing");
            Console.WriteLine(string.Format("{0}->{1}", word, newWord));
            string wordEndsWithB = "blob";
            newWord = re.Replace(wordEndsWithB, "$&ing");
            Console.WriteLine(string.Format("{0}->{1}", word, newWord));

            // Satrts with any prefix
            word = "postnuclear";
            string[] prefixes = { "pre" , "post"};
            string startsWithAnyPrefix = string.Format("^({0}|{1})", prefixes[0], prefixes[1]);
            re = new Regex(startsWithAnyPrefix);
            newWord = re.Replace(word, "");
            Console.WriteLine(string.Format("{0}->{1}", word, newWord));

        }
    }
}
