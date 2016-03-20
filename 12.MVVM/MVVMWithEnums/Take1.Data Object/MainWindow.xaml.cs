using System.Windows;

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
