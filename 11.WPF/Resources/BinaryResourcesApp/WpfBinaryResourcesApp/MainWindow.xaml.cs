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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace WpfBinaryResourcesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<BitmapImage> images = new List<BitmapImage>();
        // Current position in the list.
        private int currImage = 0;
        private const int MAX_IMAGES = 2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = Environment.CurrentDirectory;
                // Load these images when the window loads.
                // From folder on the disk
                images.Add(new BitmapImage(new Uri(string.Format(@"{0}\Images\deer.jpg", path)))); // Content, copy
                images.Add(new BitmapImage(new Uri(string.Format(@"{0}\Images\dog.jpg", path))));
                // from assembly
                images.Add(new BitmapImage(new Uri(@"/Images/Welcome.jpg", UriKind.Relative))); // Resource, do not copy
                // Show first image in the List<>.
                imageHolder.Source = images[currImage];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPreviousImage_Click(object sender, RoutedEventArgs e)
        {
            if (--currImage < 0)
                currImage = MAX_IMAGES;
            imageHolder.Source = images[currImage];
        }

        private void btnNextImage_Click(object sender, RoutedEventArgs e)
        {
            if (++currImage > MAX_IMAGES)
                currImage = 0;
            imageHolder.Source = images[currImage];
        }
    }
}
