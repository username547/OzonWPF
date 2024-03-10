using System.Windows.Input;

namespace Ozon.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _executeAction;
        public RelayCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
        }
        public bool CanExecute(object? parameter) => true;
        public void Execute(object? parameter)
        {
            _executeAction(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        /*private readonly Action<object?> executeAction;
        private readonly Func<object?, bool> canExecute;

        public RelayCommand(Action<object?> executeActionParameter, Func<object?, bool>? canExecuteParameter = null)
        {
            executeAction = executeActionParameter ?? throw new ArgumentNullException(nameof(executeActionParameter));
            canExecute = canExecuteParameter ?? (parameter => true);
        }

        public bool CanExecute(object? parameter) => canExecute(parameter);

        public void Execute(object? parameter)
        {
            if (CanExecute(parameter))
                executeAction(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }*/
    }
}
