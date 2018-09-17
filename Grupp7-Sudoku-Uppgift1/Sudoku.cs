using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_Sudoku_Uppgift1
{
    public class Sudoku
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
                    col = 0;
                    row++;
                }
            }
            return sudokuBoard;
        }



        public void BoardAsText()
        {
            int tableHeight = 10; // 10 Rows in table to reach bottom of the 9 rows
            int tableWidth = 11; // 11 Cols in table to reach left and right side and place '|'

            Console.WriteLine("+-----------------------------+");
            for (int row = 1; row < tableHeight; ++row)
            {
                Console.Write("|");
                for (int col = 1; col < tableWidth; ++col)
                {
                    if (col == 4 || col == 7)
                    {
                        Console.Write("|"); // Places a seperator between first and second 3x3 boxes
                    }
                    else if (col == 10)
                    {
                        Console.Write("|"); // Places a '|' to close the last 3x3 box
                    }
                    if (col != 10)
                    {
                        Console.Write(" {0} ", _sudokuBoard[row - 1, col - 1]);
                    }
                }
                Console.WriteLine();
                if (row % 3 == 0) // 9 % 3 gives 0 in remainder, meaning the table reached the bottom. Place the bottom line.
                {
                    Console.WriteLine("+-----------------------------+");
                }
            }
        }

        public void Solve()
        {
            int row = 0;
            do
            {
                for (int col = 0; col < _sudokuBoard.GetLength(1); col++)
                {
                    if (_sudokuBoard[row, col] == 0)
                    {
                        int solutions = 0;
                        int correctNum = 0;

                        for (int i = 1; i < 10; i++)
                        {
                            if (solutions > 1)
                            {
                                solutions = 0;
                                break;
                            }
                            //if (checkColRowBox)
                            {
                                correctNum = i;
                                solutions++;
                            }
                        }
                        if (solutions == 1 && correctNum != 0)
                        {
                            _sudokuBoard[row, col] = correctNum;
                        }
                    }
                }
                row++;
            } while (NoEmptyCell());

        }

        private bool NoEmptyCell()
        {
            for (int row = 0; row < _sudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < _sudokuBoard.GetLength(1); col++)
                {
                    if (_sudokuBoard[row, col] == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
