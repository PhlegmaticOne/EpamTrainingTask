using System;
using System.Windows.Input;

namespace GreatestCommonFactor.UI
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _canExecute;
        public event EventHandler CanExecuteChanged;
        public DelegateCommand(Action<object> action, Predicate<object> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute.Invoke(parameter);
        }
        public void Execute(object parameter)
        {
            _action?.Invoke(parameter);
        }
        public void RaiseCanExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}