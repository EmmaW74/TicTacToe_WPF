using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;

namespace TicTacToe_WPF
{
    public enum WinOrDraw
    {
        WIN,
        DRAW,
        NONE
    }

    public enum Diagonal
    {
        FROMTOPLEFT,
        FROMTOPRIGHT
    }

    public class Grid
    //Creates gameboard and manages updates and win checking
    {
        public ObservableCollection<Nullable<bool>> gameBoard { get; set; }
        private int gridDimension { get; set; }
        private int turnsTaken { get; set; }

        public Grid()
        {
            gridDimension = 3;
            turnsTaken = 0;
            gameBoard = new ObservableCollection<Nullable<bool>>();
            for (int x = 0; x < gridDimension * gridDimension; x++)
            {
                gameBoard.Add(null);
            }
        }

        public bool UpdateGrid(int chosenCell, Player currentPlayer)
        {
            // move is cell no 0 to 9
            if (gameBoard[chosenCell] == null)
            {
                if (currentPlayer.PlayerID == 1)
                {
                    gameBoard[chosenCell] = true;
                }
                else
                {
                    gameBoard[chosenCell] = false;
                }

                turnsTaken++;
                return true;
            }
            else
            {

                return false;
            }

        }
        public WinOrDraw CheckWinOrDraw()
        {
            //Creates array of rows, columns and diagonals then checks if any has all true or all false values
            Nullable<bool>[][] linesToCheck = {GetColumn(0),GetColumn(1),GetColumn(2),
            GetRow(0),GetRow(1),GetRow(2), GetDiagonal(Diagonal.FROMTOPLEFT),GetDiagonal(Diagonal.FROMTOPRIGHT)};

            foreach (Nullable<bool>[] line in linesToCheck)
            {
                if (Array.TrueForAll(line, XWins) || Array.TrueForAll(line, OWins))
                {
                    return WinOrDraw.WIN;
                }
            }
            if (turnsTaken == (gridDimension * gridDimension))
            {
                return WinOrDraw.DRAW;
            }
            return WinOrDraw.NONE;
        }

        private static bool XWins(Nullable<bool> itemToCheck)
        {
            if (itemToCheck == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool OWins(Nullable<bool> itemToCheck)
        {
            if (itemToCheck == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Nullable<bool>[] GetColumn(int columnNo)
        {
            //Returns array of the values in the given column number
            Nullable<bool>[] columnArray = new Nullable<bool> [gridDimension];
            int pos = 0;
            for(int x = 0; x < gameBoard.Count; x++)
            {
                if (x%3 == columnNo)
                {
                    columnArray[pos] = gameBoard[x];
                    pos++;
                }
            }
            return columnArray;
        }

        private Nullable<bool>[] GetRow(int rowNo)
        {
            //Returns array of the values in the given row number
            Nullable<bool>[] rowArray = new Nullable<bool>[gridDimension];
            int start = rowNo * 3;
            int y = 0;
            for (int x = start; x <= start + 2; x++)
            {
                rowArray[y] = gameBoard[x];
                y++;
            }
            return rowArray;
        }

        private Nullable<bool>[] GetDiagonal(Diagonal direction) 
        {
            //Returns array of the values in the given diagonal
            Nullable<bool>[] diagonalArray = new Nullable<bool>[gridDimension];
            int pos = 0;
            if (direction == Diagonal.FROMTOPLEFT)
            {
                for (int x = 0; x < gameBoard.Count;)
                {
                    diagonalArray[pos] = gameBoard[x];
                    x += (gridDimension + 1);
                    pos++;
                }
            }
            else
            {
                int x = (gridDimension - 1);
                for (pos = 0; pos < gridDimension; pos++)
                {
                    diagonalArray[pos] = gameBoard[x];
                    x += (gridDimension - 1);
                }
            }
            return diagonalArray;
        }
    }
}
