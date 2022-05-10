using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TicTacToe_WPF.Commands;
using TicTacToe_WPF.View;

namespace TicTacToe_WPF.ViewModel
{

    public class ExitVM : INotifyPropertyChanged
    {
        bool exitGame { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public MyRelayCommand CmdExit { get; set; }

        public ExitVM()   
        {        
            CmdExit = new MyRelayCommand(parameter =>
            {
                string value = parameter as string;
                Exit this_window = parameter as Exit;
                if (value == "yes")
                {
                    ExitGame();
                }
                else
                {
                    this_window.Close();
                }
               
            }, parameter => true);
        }
       

        public void ExitGame()
        {
            Application.Current.Shutdown();
        }
    }
}
