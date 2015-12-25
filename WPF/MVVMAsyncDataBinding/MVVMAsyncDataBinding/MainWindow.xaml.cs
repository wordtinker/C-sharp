using System.Windows;
using MicroMvvm;

namespace MVVMAsyncDataBinding
{
    public class BadMainViewModelA
    {
        public BadMainViewModelA()
        {
            // BAD CODE!!!
            UrlByteCount =
              MyStaticService.CountBytesInUrlAsync("http://www.example.com").Result;
            // APP wont show up until this code finishes.
            // Possibility of deadlock.
        }
        public int UrlByteCount { get; private set; }
    }

    public class BadMainViewModelB : ObservableObject
    {
        public BadMainViewModelB()
        {
            Initialize();
        }
        // BAD CODE!!!
        // any errors raised by the asynchronous operation will crash the application by default
        private async void Initialize()
        {
            UrlByteCount = await MyStaticService.CountBytesInUrlAsync(
              "http://www.example.com");
        }
        private int _urlByteCount;
        public int UrlByteCount
        {
            get { return _urlByteCount; }
            private set { _urlByteCount = value; RaisePropertyChanged("UrlByteCount"); }
        }
    }

    public class MainViewModel
    {
        public MainViewModel()
        {
            UrlByteCount = new NotifyTaskCompletion<int>(
              MyStaticService.CountBytesInUrlAsync("http://www.example.com"));
        }
        public NotifyTaskCompletion<int> UrlByteCount { get; private set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // the label content is data-bound to NotifyTask­Completion<T>.Result,
            // not Task<T>.Result. NotifyTaskCompletion<T>.Result is data-binding
            // friendly: It is not blocking, and it will notify the binding when
            // the task completes.
            DataContext = new MainViewModel();
            InitializeComponent();
        }
    }
}
