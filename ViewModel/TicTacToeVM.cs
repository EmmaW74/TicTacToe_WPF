using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe_WPF.Commands;

namespace TicTacToe_WPF.ViewModel
{
    public class TicTacToeVM: INotifyPropertyChanged
    {
        private string commentary;

        public string Commentary
        {
            get { return commentary; }
            set
            {
                commentary = value;
                OnPropertyChanged("Commentary"); 
            }
        }
        /*
        private string chosenCell;

        public string ChosenCell
        {
            get { return chosenCell; }
            set
            {
                chosenCell = value;
                OnPropertyChanged("ChosenCell");
            }
        }
        */
        public ButtonClickCommand ButtonClickCommand { get; set; }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private UserPlayer User1 { get; set; }
        private Player User2 { get; set; }
        public Grid GameGrid { get; set; }
        private bool gameRunning;

        public event PropertyChangedEventHandler PropertyChanged;

        private Player currentPlayer;
        public Player CurrentPlayer 
        {
            get {
                return currentPlayer;
             }
            set { 
                currentPlayer = value;
                //OnChanged bit
                UpdateCommentary(currentPlayer.TakeTurnText);
                }
        }

        public TicTacToeVM()
        {
            User1 = new UserPlayer("Emma");
            GameGrid = new Grid();
            User2 = new ComputerPlayer();
            CurrentPlayer = User1;
            ButtonClickCommand = new ButtonClickCommand(this);
            //Commentary = "Test";
            
        }

        public void RunGame()
        {
            gameRunning = true;
            UpdateCommentary(CurrentPlayer.TakeTurnText); //This isn't working
            

        }

        public void UpdateCommentary(string newText)
        {
            Commentary = newText;
        }

        

        public bool TakeTurn(int chosenCell)
        {
            //Update grid & check for win
            if (GameGrid.UpdateGrid(chosenCell, CurrentPlayer))
            {
                if (GameGrid.CheckWinOrDraw() == WinOrDraw.WIN)
                {
                    UpdateCommentary(CurrentPlayer.GameWonText);
                    return true;
                } 
                else if (GameGrid.CheckWinOrDraw() == WinOrDraw.DRAW)
                {
                    UpdateCommentary(CurrentPlayer.DrawText);
                    return true;
                } 
                else
                {
                    if (CurrentPlayer == User1)
                    {
                        CurrentPlayer = User2;
                    }
                    else
                    {
                        CurrentPlayer = User1;
                    }
                    return true;
                }
            } 
            else
            {
                UpdateCommentary(CurrentPlayer.TryAgainText);
                return false;
            }

          

        }



        
    }
}
