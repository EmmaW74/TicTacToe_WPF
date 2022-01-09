using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TicTacToe_WPF
{
    class GameController
    //Stores game elements and controls flow
    {
        /*
        public UserPlayer User1 { get; set; }
        public Player User2 { get; set; }
        public Grid GameGrid { get; set; }
        public ConsoleRender MyRenderer { get; set; }
        public bool gameRunning;
        public Player CurrentPlayer { get; set; }
        public MainWindow gameWindow { get; }
        


        public GameController(MainWindow wnd)
        {
            User1 = new UserPlayer("Emma", MyRenderer);
            GameGrid = new Grid();
            User2 = new ComputerPlayer(MyRenderer);
            gameWindow = wnd;
        }

        // public void StartGame(){} - You'll choose between 1 and 2 players

        //Starts game
        public void RunGame()
        {
            gameRunning = true;
            CurrentPlayer = User1;
            gameWindow.UpdateCommentary(CurrentPlayer.TakeTurnText);
        }

        
        //Handles user turn to update grid and check for win
        public bool HandleUserTurn(int turn)
        {
            if (!GameGrid.UpdateGrid(turn, CurrentPlayer))
            {
                //if grid not successfully updated, show try again text and return false
                gameWindow.UpdateTextHelper(() =>
                {
                    gameWindow.UpdateCommentary(CurrentPlayer.TryAgainText);
                });
                return false;
            }
            else
            {
                //update button name and check for win
                gameWindow.UpdateTextHelper(() =>
                {
                    gameWindow.UpdateButton(turn.ToString(), CurrentPlayer.NoughtOrCross);
                });
                gameWindow.UpdateTextHelper(() =>
                {
                    gameWindow.UpdateCommentary(CheckForWin());
                });
                return true;
            }        
        }

        //Handles computer turn to update grid and check for win (LOOK AT COMBINING THIS WITH HANDLE USER TURN)
        public void HandleComputerTurn()
        {
            if (gameRunning==true)
            {
                System.Diagnostics.Trace.WriteLine($"Game running: {gameRunning}");
                gameWindow.UpdateTextHelper(() =>
                {
                    gameWindow.UpdateCommentary(CurrentPlayer.TakeTurnText);
                });

                int turn;
                bool taken = false;
                while (!taken)
                {
                    turn = CurrentPlayer.GetChoiceOfCell();
                    if (!GameGrid.UpdateGrid(turn, CurrentPlayer))
                    {
                        //if grid not successfully updated, show try again text
                        gameWindow.UpdateTextHelper(() =>
                        {
                            gameWindow.UpdateCommentary(CurrentPlayer.TryAgainText);
                        });
                    }
                    else
                    {
                        //if turn is valid, update button text and check for win
                        gameWindow.UpdateTextHelper(() =>
                        {
                            gameWindow.UpdateButton(turn.ToString(), CurrentPlayer.NoughtOrCross);
                        });
                        gameWindow.UpdateTextHelper(() =>
                        {
                            gameWindow.UpdateCommentary(CheckForWin());
                        });
                        taken = true;
                    }
                }
                Thread.Sleep(3000);
            }
        }

        public string CheckForWin() 
        {
            if (GameGrid.CheckWinOrDraw() == WinOrDraw.WIN)
            {
                gameRunning = false;
                return CurrentPlayer.GameWonText;
            }
            else if (GameGrid.CheckWinOrDraw() == WinOrDraw.DRAW)
            {
                gameRunning = false;
                return "It's a draw";  
            } 
            else
            {
                CurrentPlayer = (CurrentPlayer == User1) ? User2 : User1;
                return CurrentPlayer.TakeTurnText;
            }
        }

        public void EndGame(){
            Thread.Sleep(3000);
            GameOver gameOverWindow = new GameOver();
            gameOverWindow.Show();

        } */


    }
}
