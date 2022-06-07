using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action Execute) : this(Execute, null) { }
        public RelayCommand(Action Execute, Func<bool> canExecute)
        {
            _execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = canExecute;
        }

        private readonly Action _execute;
        private readonly Func<bool> _CanExecute;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            /// <summary>
            /// defines the method that determines whether the command can execute in its current state
            /// </summary>
            /// <param name="parameter"> parameter means data used by the command</param>
            /// command does not require data to be passed, so parameter can be ignored
            /// <returns></returns>
            /// 
            if (_CanExecute == null)
            {
                return true;
            }
            if (parameter == null)
            {
                return this._CanExecute();
            }
            return this._CanExecute();
        }

        public virtual void Execute(object? parameter)
        {
            /// when the command is invoked the method should be called, here again data does not have to be passed, do parameter can be ignored
            this._execute();
        }
        internal void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
