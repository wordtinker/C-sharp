using System;
using Prism.Mvvm;
using Prism.Commands;

namespace BasicPrismApp
{
    class MainViewModel: BindableBase
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetProperty(ref _firstName, value);
                // See ctor for another method
                //UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetProperty(ref _lastName , value);
                //UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private DateTime? _lastUpdated;
        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
            set { SetProperty(ref _lastUpdated, value); }
        }

        public DelegateCommand UpdateCommand { get; set; }

        public MainViewModel()
        {
            UpdateCommand = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => FirstName).ObservesProperty(() => LastName);
        }

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName);
        }

        private void Execute()
        {
            LastUpdated = DateTime.Now;
        }

        //public DelegateCommand UpdateCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(
        //            () => { LastUpdated = DateTime.Now; },
        //            () => { return !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName); })
        //            .ObservesProperty(() => FirstName)
        //            .ObservesProperty(() => LastName);
        //    }
        //}
    }
}
