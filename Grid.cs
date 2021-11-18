using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TicTacToe_WPF
{
    public enum WinOrDraw
    {
        WIN,
        DRAW,
        NONE
    }

    class Grid
    //Stores grid and manages updates and win checking
    {
        //public Nullable<bool>[,] GameBoard { get; set; } //Auto property for get and set

        public Nullable<bool> [] newGameBoard { get; set; }



        private ConsoleRender gameConsole;
        private int gridDimension { get; set; }
        private int turnsTaken { get; set; }

        public Grid()
        {
            //creates array of null values for grid
            gridDimension = 3;
            turnsTaken = 0;
            newGameBoard = new Nullable<bool>[gridDimension * gridDimension];
            for (int x = 0; x < gridDimension*gridDimension; x++)
            {
                newGameBoard[x] = null;
            }
        }


        public bool UpdateGrid(int move, Player currentPlayer)
        {
            // move is cell no 0 to 9
            if (newGameBoard[move] == null)
            {
                switch (currentPlayer.NoughtOrCross)
                {
                    case Token.X:
                        newGameBoard[move] = true;
                        System.Diagnostics.Trace.WriteLine($"Updating: {currentPlayer.PlayerName},{currentPlayer.NoughtOrCross}");
                        break;
                    case Token.O:
                        newGameBoard[move] = false;
                        System.Diagnostics.Trace.WriteLine($"Updating: {currentPlayer.PlayerName},{currentPlayer.NoughtOrCross}");
                        break;
                    default:
                        //newGameBoard[move] = null;
                        System.Diagnostics.Trace.WriteLine($"Updating: default - return false");
                        return false;
                        //break;
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
            Nullable<bool>[][] linesToCheck = {GetColumn(0),GetColumn(2),GetColumn(2),
            GetRow(0),GetRow(1),GetRow(2), GetDiagonal(0),GetDiagonal(1)};

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


        Predicate<Nullable<bool>> predicateTrue = XWins;
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

        Predicate<Nullable<bool>> predicateFalse = OWins;
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


        private int mapColumn(char row)
        {
            switch (row)
            {
                case 'A': return 0;
                case 'B': return 1;
                case 'C': return 2;
                default: return 0;
            }
        }

        private int mapRow(char column)
        {
            return (int)Char.GetNumericValue(column) - 1;
        }


        private static bool CheckX(Nullable<bool> value)
        {
            return (value == true);
        }

        private bool CheckO(Nullable<bool> value)
        {
            return (value == false);
        }


        private Nullable<bool>[] GetColumn(int columnNo)
        {
            //use modulus 3 to identify items & extract into a fresh array
            Nullable<bool>[] temp = new Nullable<bool> [gridDimension];
            int pos = 0;
            for(int x = 0; x < newGameBoard.Length; x++)
            {
                if (x%3 == columnNo)
                {
                    temp[pos] = newGameBoard[x];
                    pos++;
                }
            }
            return temp;
        }

        private Nullable<bool>[] GetRow(int rowNo)
        {
            //start is rowNo, end is rowNo + 2 - extract range into new array
            Nullable<bool>[] temp = new Nullable<bool>[gridDimension];
            Array.Copy(newGameBoard, rowNo, temp, 0, gridDimension);
            return temp;
        }

        private Nullable<bool>[] GetDiagonal(int direction) //direction should be 0 or 1 - can I have an enum for this?
        {
            Nullable<bool>[] tempArray = new Nullable<bool>[gridDimension];
            int pos = 0;
            if (direction == 1)
            {
                for (int x = 0; x < newGameBoard.Length;)
                {
                    tempArray[pos] = newGameBoard[x];
                    x += (gridDimension + 1);
                    pos++;
                }
            }
            else
            {
                int x = (gridDimension - 1);
                for (pos = 0; pos < gridDimension; pos++)
                {
                    tempArray[pos] = newGameBoard[x];
                    x += (gridDimension - 1);
                    
                }
            }
            return tempArray;
        }
    }
}
