using System;
using System.Text;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("This is string builder.");
            sb.Append(10);
            sb.Append("text");
            string substr = "substring";
            sb.AppendFormat("And even format {0}", substr);
            Console.WriteLine(sb.ToString());
        }
    }
}
