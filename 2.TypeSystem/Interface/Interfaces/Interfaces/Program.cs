using System;

namespace Interfaces
{
    interface ISimple
    {
        void CallMethod();
    }

    class Shape
    {

    }

    class Triangle : Shape, ISimple
    {
        public void CallMethod()
        {
            Console.WriteLine("I can do method.");
        }
    }

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
            Invoice iv = new Invoice(new object[] { "object", "object" });
            iv.SaveToPDF();
            iv.SaveToWord();

            Shape triangle = new Triangle(); // Watch Shape type here!
                                             // triangle.CallMethod(); won't compile

            // 1
            try
            {
                Triangle tr = (Triangle)triangle;  // use cast to get an access to interface
                tr.CallMethod();
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

            // 2
            Triangle tr2 = triangle as Triangle; // Will give null on unsucessful cast
            if (tr2 != null)
            {
                tr2.CallMethod();
            }
            else
            {
                Console.WriteLine("No interface here.");
            }

            // 3
            if (triangle is ISimple)
            {
                ((Triangle)triangle).CallMethod();
            }
            else
            {
                Console.WriteLine("No interface here.");
            }
        }
    }

}

