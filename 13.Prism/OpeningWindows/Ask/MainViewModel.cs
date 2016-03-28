using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;
using Prism.Interactivity.InteractionRequest;

namespace Ask
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

        public ICommand ConfirmationCommand { get; private set; }
        public InteractionRequest<IConfirmation> ConfirmationRequest { get; private set; }

        public MainViewModel()
        {
            ConfirmationRequest = new InteractionRequest<IConfirmation>();
            ConfirmationCommand = new DelegateCommand(() =>
            {
                ConfirmationRequest.Raise(new Confirmation
                {
                    Title = "Confirmation box",
                    Content = "Confirmation message displayed"
                },
                (dialog) =>
                {
                    if (dialog.Confirmed)
                    {
                        Status = "Confirmed";
                    }
                    else
                    {
                        Status = "Cancelled";
                    }
                });
            });
        }
    }
}
