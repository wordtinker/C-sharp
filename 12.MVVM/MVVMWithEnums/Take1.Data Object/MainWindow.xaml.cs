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

namespace Take1.Data_Object
{
    public enum MyEnum
    {
        EnumVal1,
        EnumVal2,
        EnumVal3
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        MyEnum _EnumProp = MyEnum.EnumVal2;
        public MyEnum EnumProp
        {
            get { return _EnumProp; }
            set { _EnumProp = value; }
        }
    }
}
