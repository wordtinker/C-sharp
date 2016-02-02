using MicroMvvm;
using System;
using System.Threading.Tasks;


/// <summary>
/// NotifyTaskCompletion<T> handles one use case: When you have an asynchronous
/// operation and want to data bind the results. This is a common scenario when
/// doing data lookups or loading during startup.
/// https://msdn.microsoft.com/en-us/magazine/dn605875.aspx
/// </summary>
public sealed class NotifyTaskCompletion<TResult> : ObservableObject
{
    public NotifyTaskCompletion(Task<TResult> task)
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
}
