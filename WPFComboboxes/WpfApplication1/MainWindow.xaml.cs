using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    class SpecialColor
    {
        public string Name{ get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<SpecialColor> cars = new ObservableCollection<SpecialColor>(
                new List<SpecialColor>()
                {
                    new SpecialColor{ Name = "Red" },
                    //new SpecialColor{ Name = "Green" },
                    //new SpecialColor { Name = "Blue" }
                });
            cmbColors.ItemsSource = cars;
            cmbColors.SelectedIndex = 0;
            cars.Add(new SpecialColor { Name = "Black" });
            cars.RemoveAt(0);
            cars.RemoveAt(0); // Remove last car from the combobox
        }

        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(string.Format("Selection changed: {0}", cmbColors.SelectedIndex.ToString()));
            if (cmbColors.SelectedIndex == -1)
            {
                cmbColors.SelectedIndex = 0;
            }
        }
    }
}
