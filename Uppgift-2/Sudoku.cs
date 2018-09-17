using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_2
{
    class Sudoku
    {
        #region Fields
        private int[,] _sudokuBoard;

        #endregion

        #region Constructors

        public Sudoku(string board)
        {
            _sudokuBoard = GenerateBoard(board);
        }

        #endregion

        #region Methods

        private int[,] GenerateBoard(string board)
        {
            char[] boardCharArray = board.ToCharArray();
            int[,] sudokuBoard = new int[9, 9];

            int row = 0;
            int col = 0;

            foreach (var ch in boardCharArray)
            {
                int parsedChar = int.Parse(ch.ToString());
                sudokuBoard[row, col] = parsedChar;
                col++;
                if (col == 9)
                {
                    col = 0; row++;
                }
            }
            return sudokuBoard;

        }

        public void PrintSuduko()
        {
            int tableHeight = 10; // 9 rader + 1 för att nå botten
            int tableWidth = 11; // För att placera ett | på var del av sidorna 1 + 9 + 1

            Console.WriteLine("+-----------------------------+");
            for (int row = 1; row < tableHeight; ++row)
            {
                Console.Write("|");
                for (int col = 1; col < tableWidth; ++col)
                {
                    if (col == 4 || col == 7)
                    {
                        Console.Write("|");
                    }
                    else if (col == 10)
                    {
                        Console.Write("|");
                    }
                    if (col != 10)
                    {
                        Console.Write(" {0} ", _sudokuBoard[row - 1, col - 1]);
                    }
                }
                Console.WriteLine();
                if (row % 3 == 0) // 9 % 3 ger 0 i rest, då har raden nått slutet. Printar ut botten.
                {
                    Console.WriteLine("+-----------------------------+");
                }
            }
        }

        public bool Solve()
        {
            // FÖR VARJE row
                // FÖR VARJE col
                    // OM cell == 0
                        // Testa nummer 1-9
                            // OM ControlRowBox(row, col, nummer) = true
                                // Placera nummer i cell
                                    // OM Solve()  -Rekursivt, hoppar upp till första kommentaren
                                    // return true
                                    // ANNARS cell = 0
                        // return false, inget av nummer 1-9 fungerar, hoppa ur denna rekursiva metoden. Går till Else och sätter cell till 0.
                       
            // return true, sudukon är löst

            return true;

        }



        private bool ControlRowColBox(int row, int col, int num)
        {
            int rowStart = (row / 3) * 3; // Sätter värde till 0, 3 eller 6 för att kontrollera "boxen"
            int colStart = (col / 3) * 3; // index 0-2 blir 0, 3-5 blir 3, 6-8 blir 6

            for (int i = 0; i < 9; i++)
            {
                if (_sudokuBoard[row, i] == num) return false; // Kontrollerar hela raden för row-index
                if (_sudokuBoard[i, col] == num) return false; // Kontrollerar hela kolumen col-index
                if (_sudokuBoard[rowStart + (i % 3), colStart + (i / 3)] == num) return false;
                // kontrollarer "boxen" index-positionen i rowStart respektive colStart
                // i % 3 kommer att ge index för rowStart +1 och +2
                // i / 3 kommer att ge index colStart +1, +2, och +3
                // Då kontrolleras första index i "boxen" 2 rader ner och 3 kolumner bred. (3x3)
            }
            return true;
        }

        private bool NoEmptyCell()
        {
            for (int row = 0; row < _sudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < _sudokuBoard.GetLength(1); col++)
                {
                    if (_sudokuBoard[row, col] == 0) return true;
                }
            }
            return false;
        }

        #endregion
    }
}
