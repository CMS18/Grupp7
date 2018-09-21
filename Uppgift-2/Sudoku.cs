using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uppgift_2
{
    class Sudoku
    {
        #region Fields
        private int[,] _sudokuBoard { get; set; }
        Random _rand = new Random();

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

        public void PrintSudoku()
        {
            int tableHeight = 10; // 9 rader + 1
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
                        if (_sudokuBoard[row - 1, col - 1] == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" {0} ", _sudokuBoard[row - 1, col - 1]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" {0} ", _sudokuBoard[row - 1, col - 1]);
                            Console.ResetColor();
                        }

                    }

                }
                Console.WriteLine();
                if (row % 3 == 0) // 9 % 3 ger 0 i rest, då har raden nått slutet. Printar ut botten.
                {
                    Console.WriteLine("+-----------------------------+");
                }
            }

        }

        private bool ControlRowColBox(int row, int col, int num)
        {
            int rowStart = (row / 3) * 3; // Sätter rowStart till 0, 3 eller 6, för att få index till början av "boxen"
            int colStart = (col / 3) * 3; // Sätter colStart till 0, 3 eller 6, för att få index till början av "boxen"

            for (int i = 0; i < 9; i++)
            {
                if (_sudokuBoard[row, i] == num) return false; // Kontrollerar hela raden
                if (_sudokuBoard[i, col] == num) return false; // Kontrollerar hela kolumen
                if (_sudokuBoard[rowStart + (i % 3), colStart + (i / 3)] == num) return false;
                // kontrollerar "boxen" genom rowstart & colStart för att utgå från första index i rutnätet och kontrollerar
                // 0-2 index från cellens position åt både row/col.
            }
            return true;
        }

        private bool ContainsEmptyCell()
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

        public void Solve()
        {
            int tries = 1;
            do
            {
                for (int row = 0; row < _sudokuBoard.GetLength(0); row++)
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
                                if (ControlRowColBox(row, col, i))
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
                }
                if (tries == 0) break;
                tries--;
            } while (ContainsEmptyCell());

            if (StartGuessing())
            {
                Console.SetCursorPosition(0, 0);
                PrintSudoku();
                Console.ReadKey();
            }
        }

        private bool StartGuessing()
        {
            Thread.Sleep(10);

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (_sudokuBoard[row, col] == 0)
                    {
                        for (int number = 1; number < 10; number++) // Testar nr 1 - 10
                        {
                            if (ControlRowColBox(row, col, number)) // Kollar om numret inte finns i rad/kol/box
                            {
                                _sudokuBoard[row, col] = number;
                                Console.SetCursorPosition(0, 0);
                                PrintSudoku();
                                Solve(); // Hoppar in i första Solve och testar lösa den med detta nummer.
                                _sudokuBoard[row, col] = 0; // Kommer ut så blir cellen Noll och forsätter for-loopen här inne och testar nästa nummer
                                Console.SetCursorPosition(0, 0);
                                PrintSudoku();
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion
    }
}


