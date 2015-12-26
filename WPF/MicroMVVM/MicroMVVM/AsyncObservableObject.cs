using System;
using System.Threading.Tasks;

namespace MicroMvvm
{
    /// <summary>
    /// Wrapper for Task item that can be used for data binding.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public sealed class AsyncObservableObject<TResult> : ObservableObject
    {
        // Properties
        public Task<TResult> Task { get; private set; }
        public Task TaskCompletion { get; private set; }
        public TResult Result
        {
            get
            {
                return (Task.Status == TaskStatus.RanToCompletion) ?
                    Task.Result : default(TResult);
            }
        }
        public TaskStatus Status { get { return Task.Status; } }
        public bool IsCompleted { get { return Task.IsCompleted; } }
        public bool IsNotCompleted { get { return !Task.IsCompleted; } }
        public bool IsSuccessfullyCompleted
        {
            get
            {
                return Task.Status == TaskStatus.RanToCompletion;
            }
        }
        public bool IsCanceled { get { return Task.IsCanceled; } }
        public bool IsFaulted { get { return Task.IsFaulted; } }
        public AggregateException Exception { get { return Task.Exception; } }
        public Exception InnerException
        {
            get
            {
                return (Exception == null) ? null : Exception.InnerException;
            }
        }
        public string ErrorMessage
        {
            get
            {
                return (InnerException == null) ? null : InnerException.Message;
            }
        }

        // Constructors
        public AsyncObservableObject(Task<TResult> task)
        {
            Task = task;
            if (!task.IsCompleted)
            {
                TaskCompletion = WatchTaskAsync(task);
            }
        }

        private async Task WatchTaskAsync(Task task)
        {
            try
            {
                await task;
            }
            catch
            {
                // Capture any exceptions in the task
                // and set properties.
            }

            RaisePropertyChanged("Status");
            RaisePropertyChanged("IsCompleted");
            RaisePropertyChanged("IsNotCompleted");
            if (task.IsCanceled)
            {
                RaisePropertyChanged("IsCanceled");
            }
            else if (task.IsFaulted)
            {
                RaisePropertyChanged("IsFaulted");
                RaisePropertyChanged("Exception");
                RaisePropertyChanged("InnerException");
                RaisePropertyChanged("ErrorMessage");
            }
            else
            {
                RaisePropertyChanged("IsSuccessfullyCompleted");
                RaisePropertyChanged("Result");
            }
        }
    }
}
