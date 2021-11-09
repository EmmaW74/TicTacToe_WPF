using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        public MainWindow gameWindow { get; }
        int Event { get; set; }


        public GameController(MainWindow wnd)
        {
           
            User1 = new UserPlayer("Emma", MyRenderer);
            GameGrid = new Grid();
            User2 = new ComputerPlayer(MyRenderer);
            gameWindow = wnd;

            //test
            Event = 0;

        }

        // public void StartGame(){} - You'll choose between 1 and 2 players

        public void RunGame()
        {
            gameRunning = true;
            CurrentPlayer = User1;
            gameWindow.UpdateCommentary(CurrentPlayer.TakeTurnText);

        }

        //public void EndGame(){}

        public async Task HandleTurn(int turn)
        {   
            
            //check if valid using update grid
            if (!GameGrid.UpdateGrid(turn, CurrentPlayer))
            {
                //if not show try again text
                 gameWindow.UpdateCommentary(CurrentPlayer.TryAgainText);
            }
            else
            {
                //if valid turn check for win & update commentary
                 gameWindow.UpdateButton(turn.ToString(), CurrentPlayer.NoughtOrCross);
                 gameWindow.UpdateCommentary(CheckForWin());

           
            }
            /*if (CurrentPlayer.GetType().ToString() == "TicTacToe_WPF.ComputerPlayer")
            {
                 gameWindow.UpdateCommentary("Test");

                HandleTurn(CurrentPlayer.GetChoiceOfCell());
            }*/

           
        }
        public async Task HandleComputerTurn()
        {
            if (CurrentPlayer.GetType().ToString() == "TicTacToe_WPF.ComputerPlayer")
            {
                gameWindow.UpdateCommentary("Test");
                Thread.Sleep(500);
                HandleTurn(CurrentPlayer.GetChoiceOfCell());
            }
             

        }



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
