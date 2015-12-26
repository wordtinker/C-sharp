using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MicroMvvm
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }

    public abstract class AsyncCommandBase : ObservableObject, IAsyncCommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public abstract bool CanExecute(object parameter);
        public abstract Task ExecuteAsync(object parameter);

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        protected void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }

    public class AsyncRelayCommand<TResult> : AsyncCommandBase
    {
        // Members
        private readonly Func<Task<TResult>> _command;
        private AsyncObservableObject<TResult> _execution;
        // Properties
        public AsyncObservableObject<TResult> Execution
        {
            get { return _execution; }
            private set
            {
                _execution = value;
                RaisePropertyChanged("Execution");
            }
        }

        // Constructor
        public AsyncRelayCommand(Func<Task<TResult>> command)
        {
            _command = command;
        }
        
        public override bool CanExecute(object parameter)
        {
            return Execution == null || Execution.IsCompleted;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Execution = new AsyncObservableObject<TResult>(_command());
            RaiseCanExecuteChanged();
            await Execution.TaskCompletion;
            RaiseCanExecuteChanged();
        }
    }

    public static class AsyncRelayCommand
    {
        public static AsyncRelayCommand<object> Create(Func<Task> command)
        {
            return new AsyncRelayCommand<object>(async () => { await command(); return null; });
        }

        public static AsyncRelayCommand<TResult> Create<TResult>(Func<Task<TResult>> command)
        {
            return new AsyncRelayCommand<TResult>(command);
        }
    }
}
