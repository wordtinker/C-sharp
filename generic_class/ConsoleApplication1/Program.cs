using System;


class GenericSwapper<T>
{
    private T x; private T y;

    public GenericSwapper(T xval, T yval)
    {
        x = xval;
        y = yval;
    }

    public override string ToString()
    {
        return String.Format("{0} {1}", x, y);
    }

    public void Switch()
    {
        T temp = x;
        x = y;
        y = x;
    }
}

class Program
{
    static void Main(string[] args)
    {
        GenericSwapper<string> gs = new GenericSwapper<string>("hello", "world");
        Console.WriteLine("Before the switch: {0}", gs);
        gs.Switch();
        Console.WriteLine("After the switch: {0}", gs);
    }
}

