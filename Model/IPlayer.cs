using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_WPF.Model
{
    public enum Token
    {
        X, //true
        O   //false
    }

    public interface IPlayer
    {
        int PlayerID { get; }
        string PlayerName { get; set; }
        Token NoughtOrCross { get; set; }
        string FirstTurnText { get; }
        string TakeTurnText { get; }
        string TryAgainText { get; }
        string GameWonText { get; }
        string DrawText { get; }

        string RandomNameGenerator();
        void setPlayerTypeAttributes();
        int GetChoiceOfCell();
    }
}
