using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe_WPF.Model;
using TicTacToe_WPF;


namespace TicTacToe_WPF
{
    public class Player : IPlayer
    {
        public int PlayerID { get; }
        public string PlayerName { get; set; }
        public Token NoughtOrCross { get; set; }
        public string FirstTurnText { get; set; }
        public string TryAgainText { get; set; }
        public string TakeTurnText { get; set; }
        public string GameWonText { get; set; }
        public string DrawText { get; }

        public Player(int ID)
        {
            PlayerID = ID;
            DrawText = $"It's a draw!";
            setPlayerTypeAttributes();
        }


        public string RandomNameGenerator()
        {
            string[] nameList = { "Bob", "Charlie", "George", "Harry", "Claire", "Tina" };
            Random randomChoice = new Random();
            string nameChosen = nameList[randomChoice.Next(0, 5)];
            return nameChosen;
        }
        public void setPlayerTypeAttributes()
        {
            if (PlayerID == 1)
            {
                //set commentary for user player
                NoughtOrCross = Token.X;
                FirstTurnText = "You go first, click to add your token.";
                TakeTurnText = "Your turn, click to add your token.";
                GameWonText = "Congratulations! You win!";
                TryAgainText = "Sorry that's not valid, try again.";
            }
            else
            {
                //set commentary for computer player
                NoughtOrCross = Token.O;
                PlayerName = RandomNameGenerator();
                FirstTurnText = $"{PlayerName} goes first";
                TakeTurnText = $"{PlayerName} is taking their turn...";
                GameWonText = $"{PlayerName} wins! Better luck next time.";
                TryAgainText = $"{PlayerName}'s turn isn't valid, trying again...";
            }

        }

        public int GetChoiceOfCell()
        {
            Random randomChoice = new Random();
            int turnTaken = randomChoice.Next(0, 9);
            return turnTaken;
        }

    }
}
