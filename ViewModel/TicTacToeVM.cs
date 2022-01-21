using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe_WPF.Commands;


namespace TicTacToe_WPF.ViewModel
{
    public class TicTacToeVM: INotifyPropertyChanged
    {     
        private Player User1 { get; set; }
        private Player User2 { get; set; }
        public Grid GameGrid { get; set; }
        private Player currentPlayer;
        public Player CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }
            set
            {
                currentPlayer = value;
                Commentary = currentPlayer.TakeTurnText;
            }
        }
        private string commentary;
        public string Commentary
        {
            get { return commentary; }
            set
            {
                commentary = value;
                OnPropertyChanged(nameof(Commentary));
            }
        }
        private bool gameRunning;
        public bool GameRunning
        {
            get { return gameRunning; }
            set
            {
                gameRunning = value;
            }
        }
        private bool awaitingStart;
        public bool AwaitingStart
        {
            get { return awaitingStart; }
            set
            {
                awaitingStart = value;
                OnPropertyChanged(nameof(AwaitingStart));
            }
        }
        private bool gameOver;
        public bool GameOver
        {
            get { return gameOver; }
            set
            {
                gameOver = value;
                OnPropertyChanged(nameof(GameOver));
            }
        }
        private bool showCommentary;
        public bool ShowCommentary
        {
            get { return showCommentary; }
            set
            {
                showCommentary = value;
                OnPropertyChanged(nameof(ShowCommentary));
            }
        }
        public ButtonClickCommand ButtonClickCommand { get; set; }
        public StartButtonCommand StartButtonCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public TicTacToeVM()
        {
            User1 = new Player(1);
            GameGrid = new Grid();
            User2 = new Player(2);
            CurrentPlayer = User1;
            ButtonClickCommand = new ButtonClickCommand(this);
            AwaitingStart = true;
            StartButtonCommand = new StartButtonCommand(this);
            ShowCommentary = false;
            GameRunning = false;
            GameOver = false;
            if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                AwaitingStart = true;
                ShowCommentary = true;
                GameOver = true;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RunGame()
        {
            AwaitingStart = false;
            ShowCommentary = true;
            GameRunning = true;
            Commentary = currentPlayer.FirstTurnText;
        }
                    
        public async void TakeTurn(int chosenCell)
        {
            // User player takes turn
            bool turnComplete = false;
            int turn;
            while (!turnComplete)
            {
                //Update grid & check for win
                turn = chosenCell;          
                if (GameGrid.UpdateGrid(turn, CurrentPlayer))
                {
                    WinOrDraw result = GameGrid.CheckWinOrDraw();
                    if (result == WinOrDraw.WIN)
                    {
                        Commentary = CurrentPlayer.GameWonText;
                        turnComplete = true;
                        GameRunning = false;
                        GameOver = true;
                    }
                    else if (result == WinOrDraw.DRAW)
                    {
                        Commentary = CurrentPlayer.DrawText;
                        turnComplete = true;
                        GameRunning = false;
                        GameOver = true;
                    }
                    else
                    {                  
                        CurrentPlayer = User2;
                        Commentary = currentPlayer.TakeTurnText;
                        await Task.Delay(3000);
                        CommandManager.InvalidateRequerySuggested();
                        TakeTurn();
                        turnComplete = true;
                    }
                }
                else
                {
                    Commentary = CurrentPlayer.TryAgainText;
                    if (CurrentPlayer == User1)
                    {
                        turnComplete = true;
                    }
                }
            }
        }

        private void TakeTurn()
        {
            //computer player takes turn
            bool turnComplete = false;
            int turn;
            while (!turnComplete)
            {
                //Update grid & check for win
                turn = CurrentPlayer.GetChoiceOfCell();
                if (GameGrid.UpdateGrid(turn, CurrentPlayer))
                {
                    WinOrDraw result = GameGrid.CheckWinOrDraw();
                    if (result == WinOrDraw.WIN)
                    {
                        Commentary = CurrentPlayer.GameWonText;
                        turnComplete = true;
                        GameRunning = false;
                        GameOver = true;
                    }
                    else if (result == WinOrDraw.DRAW)
                    {
                        Commentary = CurrentPlayer.DrawText;
                        turnComplete = true;
                        GameRunning = false;
                        GameOver = true;
                    }
                    else
                    {
                        CurrentPlayer = User1;
                        turnComplete = true;
                        Commentary = currentPlayer.TakeTurnText;
                        CommandManager.InvalidateRequerySuggested();
                    }
                }
                else
                {
                    Commentary = CurrentPlayer.TryAgainText;
                }
            }
        }
        public async void ResetGame()
        {
            //reset values, null grid boxes and set loser to go first in new game
            GameOver = false;
            GameRunning = true;
            GameGrid.ClearGrid();
            CurrentPlayer = CurrentPlayer == User1?User2:User1; 
            Commentary = currentPlayer.FirstTurnText;
            ShowCommentary = true;
            if (CurrentPlayer == User2)
            {
                await Task.Delay(2000);
                TakeTurn();
            }
        }

        public void ExitGame(MainWindow window)
        {
            window.Close();
        }
    }
}
