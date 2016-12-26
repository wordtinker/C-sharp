using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompatibleSignatures
{
    class Program
    {
        static void LogPlainEvent(object sender, EventArgs e)
        {
            Console.WriteLine("LogPlain");
        }
        static void LogKeyEvent(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("LogKey");
        }
        static void LogMouseEvent(object sender, MouseEventArgs e)
        {
            Console.WriteLine("LogMouse");
        }

        static void Main(string[] args)
        {
            Button button = new Button();
            button.Text = "Click me";

            // signature of Click: object sender, EventArgs e
            // button.Click += LogPlainEvent;
            // signature of KeyPress: object sender, KeyPressEventArgs e 
            button.KeyPress += LogKeyEvent;
            // signature of MouseClick: object sender, MouseEventArgs e
            button.MouseClick += LogMouseEvent;

            // NB! since NET 2.0
            // we can use (object sender, EventArgs e) signature
            // instead of (object sender, KeyPressEventArgs e)
            button.KeyPress += LogPlainEvent;
            button.MouseClick += LogPlainEvent;

            Form form = new Form();
            form.AutoSize = true;
            form.Controls.Add(button);
            Application.Run(form);
        }
    }
}
