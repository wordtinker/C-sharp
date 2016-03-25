using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;
using Prism.Interactivity.InteractionRequest;

namespace Notify
{
    class MainViewModel : BindableBase
    {
        string _status;
        public String Status
        {
            get { return _status; }
            set
            {
                SetProperty<string>(ref _status, value);
            }
        }

        public ICommand NotificationCommand { get; private set; }
        public InteractionRequest<INotification> NotificationRequest { get; private set; }

        public MainViewModel()
        {
            NotificationRequest = new InteractionRequest<INotification>();
            NotificationCommand = new DelegateCommand(() =>
            {
                NotificationRequest.Raise(new Notification
                {
                    Title = "Notification",
                    Content = "Notification message displayed"
                },
                (i) => Status = "Done");
            });
        }
        }
}
