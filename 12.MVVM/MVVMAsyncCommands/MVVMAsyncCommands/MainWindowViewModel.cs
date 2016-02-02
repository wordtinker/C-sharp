using MicroMvvm;

namespace MVVMAsyncCommands
{
    public sealed class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {
            Url = "http://www.example.com/";
            CountUrlBytesCommand = AsyncCommand.Create(() => MyService.DownloadAndCountBytesAsync(Url));
        }

        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                RaisePropertyChanged("Url");
            }
        }

        public IAsyncCommand CountUrlBytesCommand { get; private set; }
    }
}
