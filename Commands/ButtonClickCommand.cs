using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe_WPF.ViewModel;

namespace TicTacToe_WPF.Commands
{  
// *** REPLACED BY CmdPlayClick RelayCommand ***

    public class ButtonClickCommand : ICommand
    {
        public TicTacToeVM VM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public ButtonClickCommand(TicTacToeVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            if (VM.CurrentPlayer.PlayerID == 1 && VM.GameRunning == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            int chosenCell = Convert.ToInt32(parameter);
            VM.TakeTurn(chosenCell);
        }
    }
}
