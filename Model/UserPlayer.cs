using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_WPF
{
    class UserPlayer : Player
    //Player controlled by user
    {
        override public int PlayerID { get; set; }
        override public string PlayerName { get; set; }
        override public Token NoughtOrCross { get; }
        override public string TryAgainText { get; }
        override public string TakeTurnText { get; }
        override public string GameWonText { get; }
        override public string DrawText { get; }

        public UserPlayer(string name)
        {
            PlayerName = name;
            PlayerID = 1;
            NoughtOrCross = Token.X;
            TakeTurnText = "Your turn, click to add your token.";
            GameWonText = "Congratulations! You win!";
            TryAgainText = "Sorry that's not valid, try again.";
            DrawText = $"It's a draw!";
        }

        override public int GetChoiceOfCell()
        {
            return 0;
        }

    }
}
