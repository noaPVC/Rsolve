using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rsolve.Core
{
    public class CallbackCommand : ICommand
    {
        private readonly Action<object> _callback;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CallbackCommand(Action<object> callback, Func<bool> canExecute = null)
        {
            _callback = callback;
            _canExecute = canExecute ?? (() => true);
        }

        public bool CanExecute(object parameter) => _canExecute();

        public void Execute(object parameter)
        {
            _callback?.Invoke(parameter);
        }
    }
}
