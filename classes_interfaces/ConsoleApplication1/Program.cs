using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    interface ISaveable
    {
        void SaveToPDF();
        void SaveToWord();
    }

    class Invoice : ISaveable
    {
        private object[] details;
        public Invoice(object[] det)
        {
            details = det;
        }

        public void SaveToPDF()
        {
            Console.WriteLine("Save to PDF.");
        }

        public void SaveToWord()
        {
            Console.WriteLine("Save to Word.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Invoice iv = new Invoice(new object[] { "object", "object"});
            iv.SaveToPDF();
            iv.SaveToWord();
        }
    }
}
