using System;
using System.Collections.Generic;
using System.Text;


namespace TicTacToe_WPF
{
    class ComputerPlayer : Player
    //Player controlled by app
    {

        ConsoleRender gameConsole;
        override public string PlayerName { get; set; }
        override public Token NoughtOrCross { get; }
        override public string TakeTurnText { get; }
        override public string TryAgainText { get; }
        override public string GameWonText { get; }


        public ComputerPlayer(ConsoleRender consoleInterface)
        {
            PlayerName = "Bob"; //Add random list
            gameConsole = consoleInterface;
            NoughtOrCross = Token.O;
            TakeTurnText = $"{PlayerName} is taking their turn...";
            GameWonText = $"{PlayerName} wins! Better luck next time.";
            TryAgainText = $"{PlayerName}'s turn isn't valid, trying again...";
        }

        override public int GetChoiceOfCell()
        {
            //random grid choice generator to go here


            Random randomChoice = new Random();

            int turnTaken = randomChoice.Next(0,9);

           // Thread.Sleep(300);

            return turnTaken;

          
        }
    }
}
