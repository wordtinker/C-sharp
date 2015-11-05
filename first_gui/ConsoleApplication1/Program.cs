using System;
using System.Windows.Forms;

partial class Program // class is split in two files
{
    static void Main()
    {
        lbl.Top = 50; lbl.Left = 50;
        box1.Top = 75; box1.Left = 50;
        box2.Top = 100; box2.Left = 50;

        btn.Click += butt_Click; // bind event handler

        myFrm.Controls.Add(btn);
        myFrm.Controls.Add(lbl);
        myFrm.Controls.Add(box1);
        myFrm.Controls.Add(box2);

        Application.Run(myFrm);
    }
}

