using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TicTacToe_WPF.Commands
{
    public class MyRelayCommand : ICommand
    {

            private Action<object> execute; //A predefined delegate returning nothing
            private Func<object, bool> canExecute; //A predefined delegate returning a value

            public event EventHandler CanExecuteChanged //Implementing the ICommand CanExecuteChanged method
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public MyRelayCommand(Action<object> execute, Func<object, bool> canExecute = null) //constructor takes 2 delegates which point to anon methods
            {
                this.execute = execute;
                this.canExecute = canExecute;
            }

            public bool CanExecute(object parameter) //Implements ICommand CanExecute method - returns a bool
            {
                return this.canExecute == null || this.canExecute(parameter);
            }

            public void Execute(object parameter) //Implements ICommand Execute method
            {
                this.execute(parameter);
            }

        

    }
}

