using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_WPF
{

    public enum Token
    {
        X, //true
        O   //false
    }

    public abstract class Player
    //Base class for players
    {
        abstract public int PlayerID { get; set; }
        abstract public string PlayerName { get; set; }
        abstract public Token NoughtOrCross { get; }
        abstract public string TakeTurnText { get; }
        abstract public string TryAgainText { get; }
        abstract public string GameWonText { get; }
        abstract public string DrawText { get; }

        public Player() { }
        abstract public int GetChoiceOfCell();

    }
}
