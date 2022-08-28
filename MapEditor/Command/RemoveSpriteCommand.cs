using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MapEditor.Command
{
    public class RemoveSpriteCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action<object> _action;
        private Func<object, bool> _canExecute;
        public RemoveSpriteCommand(Action<object> action, Func<object, bool> canExecute)
        {
            if (action == null) throw new ArgumentException(nameof(action));
            _action = action;
            _canExecute = canExecute;
        }
        public RemoveSpriteCommand(Action<object> action) : this(action, null) { }
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            if(parameter != null)
                _action(parameter);
        }
    }
}
