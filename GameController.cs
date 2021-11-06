using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_WPF
{
    class GameController
    //Stores game elements and controls flow
    {
        public UserPlayer User1 { get; set; }
        public Player User2 { get; set; }
        public Grid GameGrid { get; set; }
        public ConsoleRender MyRenderer { get; set; }
        public bool gameRunning;
        public Player CurrentPlayer { get; set; }


        public GameController(MainWindow wnd)
        {
           
            User1 = new UserPlayer("Emma", MyRenderer);
            GameGrid = new Grid();
            User2 = new ComputerPlayer(MyRenderer);


        }

        // public void StartGame(){} - You'll choose between 1 and 2 players

        public void RunGame()
        {
            gameRunning = true;
            CurrentPlayer = User1;
            /* while (gameRunning)
            {
                //MyRenderer.DrawGrid(GameGrid.GameBoard);
                bool turnTakenSuccessfully = false;
                 
                while (!turnTakenSuccessfully)
                {
                    turnTakenSuccessfully = GameGrid.UpdateGrid(CurrentPlayer.GetChoiceOfCell(), CurrentPlayer);
                }
                 

                if (GameGrid.CheckWinOrDraw() == WinOrDraw.WIN)
                {
                    // Console.WriteLine(CurrentPlayer.GameWonText);
                    
                    gameRunning = false;
                }
                else if (GameGrid.CheckWinOrDraw() == WinOrDraw.DRAW)
                {
                     
                    gameRunning = false;
                }
                CurrentPlayer = (CurrentPlayer == User1) ? User2 : User1;

            } */

        }

        //public void EndGame(){}



        public bool ValidateTurn(int turn)
        {
            return GameGrid.UpdateGrid(turn, CurrentPlayer); //Checks if turn is valid
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
                //return null;
                return CurrentPlayer.TakeTurnText;
            }
            
        }


    }
}
