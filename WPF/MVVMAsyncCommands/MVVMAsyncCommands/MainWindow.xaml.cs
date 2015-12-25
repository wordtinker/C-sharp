using System.Windows;


namespace MVVMAsyncCommands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // How will the UI display errors?
        // How should the UI look while the operation is in progress? (For example, will it provide immediate feedback via busy indicators?)
        // How is the user restricted while the operation is in progress? (Are buttons disabled, for example?)
        // Does the user have any additional commands available while the operation is in progress? (For instance, can he cancel the operation?)
        // If the user can start multiple operations, how does the UI provide completion or error details for each one? (For example, will the UI use a “command queue” style or notification popups?)
        // https://msdn.microsoft.com/en-us/magazine/dn630647.aspx
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}
