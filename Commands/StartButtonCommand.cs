using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe_WPF.ViewModel;

namespace TicTacToe_WPF.Commands
{
    public class StartButtonCommand : ICommand
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

        public StartButtonCommand(TicTacToeVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string value = parameter as string;
            MainWindow window = parameter as MainWindow;
            if (value == "start")
            {
                VM.RunGame();
            } else if (value == "newgame")
            {
                VM.ResetGame();
            }
            else
            {
                VM.ExitGame(window);
            }
            
        }
    }
}
