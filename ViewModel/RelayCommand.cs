using System.Windows.Input;

namespace Ozon.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _executeAction;
        public RelayCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
        }
        public bool CanExecute(object? parameter) => true;
        public void Execute(object? parameter) => _executeAction(parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /*private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter == null) return false;
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            if (parameter == null) return;
            _execute(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }*/
    }
}
