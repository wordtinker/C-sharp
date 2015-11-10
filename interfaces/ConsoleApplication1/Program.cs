using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

class Program
{
    static void Main(string[] args)
    {
        Shape triangle = new Triangle();
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
