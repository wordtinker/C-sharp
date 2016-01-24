using System;

namespace CustomConversion
{
    public struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int w, int h) : this()
        {
            Width = w;
            Height = h;
        }

        public void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return string.Format("[Width = {0}; Height = {1}]",
                Width, Height);
        }
        public static implicit operator Rectangle(Square s)
        {
            Rectangle r = new Rectangle();
            r.Height = s.Length;
            // Assume the length of the new Rectangle with
            // (Length x 2).
            r.Width = s.Length * 2;
            return r;
        }
    }

    public struct Square
    {
        public int Length { get; set; }

        public Square(int l) : this()
        {
            Length = l;
        }
        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public override string ToString()
        {
            return string.Format("[Length = {0}]", Length);
        }
        // Rectangles can be explicitly converted
        // into Squares.
        public static explicit operator Square(Rectangle r)
        {
            Square s = new Square();
            s.Length = r.Height;
            return s;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Make a Rectangle.
            Rectangle r = new Rectangle(15, 4);
            Console.WriteLine(r.ToString());
            r.Draw();
            // Convert r into a Square,
            // based on the height of the Rectangle.
            Square s = (Square)r;
            Console.WriteLine(s.ToString());
            s.Draw();
            Console.ReadLine();
            // Implicit cast OK!
            Square s3 = new Square();
            s3.Length = 7;
            Rectangle rect2 = s3;
            Console.WriteLine("rect2 = {0}", rect2);
        }
    }
}
