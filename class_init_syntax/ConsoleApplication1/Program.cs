using System;

class Point
{
    public int X { get; set; } // Auto-properties, this.x is hidded behind
    public int Y { get; set; }

    public Point(int xVal, int yVal)
    {
        X = xVal;
        Y = yVal;
    }
    public Point() { }

    public void DisplayStats()
    {
        Console.WriteLine("[{0}, {1}]", X, Y);
    }
}

class Rectangle
{
    private Point topLeft = new Point();
    private Point bottomRight = new Point();
    public Point TopLeft
    {
        get { return topLeft; }
        set { topLeft = value; }
    }
    public Point BottomRight
    {
        get { return bottomRight; }
        set { bottomRight = value; }
    }
    public void DisplayStats()
    {
        Console.WriteLine("[TopLeft: {0}, {1} BottomRight: {2}, {3}]",
        topLeft.X, topLeft.Y,
        bottomRight.X, bottomRight.Y);
    }
}

class Programm {
    static void Main()
    {
        Point p = new Point();
        p.X = 10;
        p.Y = 10;
        p.DisplayStats();

        // Shortcut using init syntax
        Point t = new Point { X = 20, Y = 20 }; // default constructor is called;
        t.DisplayStats();

        // Create using custom constructor
        Point d = new Point(30, 30);
        d.DisplayStats();

        // Init internal objects
        Rectangle myRect = new Rectangle
        {
            TopLeft = new Point { X = 10, Y = 10 },
            BottomRight = new Point { X = 200, Y = 200 }
        };
        myRect.DisplayStats();
    }
}
