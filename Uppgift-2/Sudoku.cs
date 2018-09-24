using System;

namespace Uppgift_2
{
    class Sudoku
    {
        #region Fields
        private int[,] SudokuBoard { get; }
        private int _tries;

        #endregion

        #region Constructors

        public Sudoku(string board)
        {
            SudokuBoard = GenerateBoard(board);
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
                        if (SudokuBoard[row - 1, col - 1] == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" {0} ", SudokuBoard[row - 1, col - 1]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" {0} ", SudokuBoard[row - 1, col - 1]);
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
                if (SudokuBoard[row, i] == num) return false; // Kontrollerar hela raden
                if (SudokuBoard[i, col] == num) return false; // Kontrollerar hela kolumen
                if (SudokuBoard[rowStart + (i % 3), colStart + (i / 3)] == num) return false;
                // kontrollerar "boxen" genom rowstart & colStart för att utgå från första index i rutnätet och kontrollerar
                // 0-2 index från cellens position åt både row/col.
            }
            return true;
        }

        private bool ContainsEmptyCell()
        {
            for (int row = 0; row < SudokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < SudokuBoard.GetLength(1); col++)
                {
                    if (SudokuBoard[row, col] == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Solve()
        {
            int solveTries = 1;
            do
            {
                for (int row = 0; row < SudokuBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < SudokuBoard.GetLength(1); col++)
                    {
                        if (SudokuBoard[row, col] == 0)
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
                                SudokuBoard[row, col] = correctNum;
                            }
                        }
                    }
                }
                if (solveTries == 0) break;
                solveTries--;
            } while (ContainsEmptyCell());

            if (StartGuessing())
            {
                PrintSudoku();
                Console.ReadKey();
            }

        }

        private bool StartGuessing()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (SudokuBoard[row, col] != 0) continue;

                    for (int number = 1; number < 10; number++) // Testar nr 1 - 9
                    {
                        if (!ControlRowColBox(row, col, number)) continue; // Kontrollerar om numret inte redan finns i rad/kolumn/box
                        SudokuBoard[row, col] = number; // Placerar nummer i cell
                        if (StartGuessing()) // Hoppar in i metoden rekursivt
                        {
                            return true;
                        }
                        _tries++; // Om fel gissning, addera tries med 1.
                        SudokuBoard[row, col] = 0; // Kommer ut så blir cellen Noll och forsätter for-loopen här inne och testar nästa nummer
                        if (_tries == 30000)
                        {
                            PrintSudoku();
                            Console.WriteLine("Så här långt kom jag...");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                    }
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}


