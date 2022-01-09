using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe_WPF.ViewModel;

namespace TicTacToe_WPF.Commands
{
    public class ButtonClickCommand : ICommand
    {
        public TicTacToeVM VM { get; set; }

        public event EventHandler CanExecuteChanged;

        public ButtonClickCommand(TicTacToeVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
            //need to add validation
        }

        public void Execute(object parameter)
        {
            int temp = Convert.ToInt32(parameter);
            VM.TakeTurn(temp);
        }
    }
}
