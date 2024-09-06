using System.Windows.Input;

namespace MVVMLib.Commands
{
    public class RelayCommand<T> : IRelayCommand<T>
    {
        private readonly Action<T> _execute;

        private readonly Predicate<T>? _canExecute;

        public RelayCommand(Action<T> execute, Predicate<T>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(T? parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        public void Execute(T? parameter)
        {
            _execute.Invoke((T)parameter);
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
