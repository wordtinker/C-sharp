using System.Windows;


namespace MVVMQuickExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Notice that now we don't use control-specific events here.
        // Use them as ModelView properties
        // 1. View knows View Models
        // 2. View model knows Models
        // 3. Model knows nothing about V and VM.

        public MainWindow()
        {
            InitializeComponent();
            // We have declared the view model instance declaratively in the xaml.
            // Get the reference to it here, so we can use it in the button click event.
            // _viewModel = (AlbumViewModel)base.DataContext;
        }
    }
}
