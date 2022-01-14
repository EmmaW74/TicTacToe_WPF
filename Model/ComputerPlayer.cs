﻿using System;
using System.Collections.Generic;
using System.Text;


namespace TicTacToe_WPF
{
    class ComputerPlayer : Player
    //Player controlled by app
    {
        override public int PlayerID { get; set; }
        override public string PlayerName { get; set; }
        override public Token NoughtOrCross { get; }
        override public string FirstTurnText { get; }
        override public string TakeTurnText { get; }
        override public string TryAgainText { get; }
        override public string GameWonText { get; }
        override public string DrawText { get; }


        public ComputerPlayer()
        {
            PlayerName = "Bob"; //Add random list
            PlayerID = 2;
            NoughtOrCross = Token.O;
            FirstTurnText = $"{PlayerName} goes first";
            TakeTurnText = $"{PlayerName} is taking their turn...";
            GameWonText = $"{PlayerName} wins! Better luck next time.";
            TryAgainText = $"{PlayerName}'s turn isn't valid, trying again...";
            DrawText = $"It's a draw!";
        }

        //Returns random choice of cell for computer player
        override public int GetChoiceOfCell()
        {
            Random randomChoice = new Random();
            int turnTaken = randomChoice.Next(0,9);
            return turnTaken;        
        }
    }
}
