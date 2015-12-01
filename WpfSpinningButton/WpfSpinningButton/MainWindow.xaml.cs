using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSpinningButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isSpinning = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSpinner_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isSpinning)
            {
                isSpinning = true;
                // Make a double animation object, and register
                // with the Completed event.
                DoubleAnimation dblAnim = new DoubleAnimation();
                dblAnim.Completed += (o, s) => { isSpinning = false; };
                // Set the start value and end value.
                dblAnim.From = 0;
                dblAnim.To = 360;
                dblAnim.Duration = new Duration(TimeSpan.FromSeconds(4));
                // Now, create a RotateTransform object, and set
                // it to the RenderTransform property of our
                // button.
                RotateTransform rt = new RotateTransform();
                btnSpinner.RenderTransform = rt;
                // Now, animation the RotateTransform object.
                rt.BeginAnimation(RotateTransform.AngleProperty, dblAnim);
            }
        }

        private void btnSpinner_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation dblAnim = new DoubleAnimation();
            dblAnim.From = 1.0;
            dblAnim.To = 0.0;
            // Reverse when done.
            dblAnim.AutoReverse = true;
            btnSpinner.BeginAnimation(Button.OpacityProperty, dblAnim);
        }
    }
}
