using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfApplication1
{
    public class Track
    {

        public string Title { get; set; }
        public string Artist { get; set; }
        public int Number { get; set; }
    }

    public class MultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values[1] + "-" + values[0];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string[] splitValues = ((string)value).Split('-');
            return splitValues;
        }
    }


    public class SimpleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("--{0}--", value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Track> data = new ObservableCollection<Track>();

        public MainWindow()
        {
            InitializeComponent();

            data.Add(new Track() { Title = "Think", Artist = "Aretha Franklin", Number = 7 });
            data.Add(new Track() { Title = "Minnie The Moocher", Artist = "Cab Calloway", Number = 9 });
            data.Add(new Track() { Title = "Shake A Tail Feather", Artist = "Ray Charles", Number = 4 });

            // Bind data to View class, middleman between data and DataGrid
            CollectionViewSource cvs = (CollectionViewSource)FindResource("cvs");
            cvs.Source = data;
        }
    }
}
