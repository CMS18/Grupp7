using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1
{
    public class Sudoku
    {
        #region Fields
        private int[,] _sudokuBoard = new int[9, 9];
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
            int tableHeight = 10; // 9 rader + 1 för att nå och placera botten.
            int tableWidth = 11; // För att placera ett | på var del av sidorna 1 + 9 + 1

            Console.WriteLine("+-----------------------------+");
            for (int row = 1; row < tableHeight; ++row)
            {
                Console.Write("|");
                for (int col = 1; col < tableWidth; ++col)
                {
                    if (col == 4 || col == 7) // Placerar väggen för boxen
                    {
                        Console.Write("|");
                    }
                    else if (col == 10) // Placerar vid slutet av arrayen till höger
                    {
                        Console.Write("|");
                    }
                    if (col != 10) // Skriver ut siffrorna så länge col inte är 10
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

        public void Solve()
        {
            Console.WriteLine("Press a key to solve...");
            Console.ReadKey();
            int tries = 0;

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
                tries++;
                if (NoEmptyCell() && tries == 100)
                {
                    NoSolution();
                }

            } while (NoEmptyCell());

            Console.WriteLine();
            BoardAsText();
            Console.ReadLine();
        }

        private void NoSolution()
        {
            Console.WriteLine();
            Console.WriteLine("Sudokun saknar lösning... så här långt kom jag.");
            BoardAsText();
            Console.ReadLine();
            Environment.Exit(0);
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
       

        private bool ControlRowColBox(int row, int col, int num)
        {
            int rowStart = (row / 3) * 3; // Sätter värde till 0, 3 eller 6 för att kontrollera "boxen"
            int colStart = (col / 3) * 3; // index 0-2 = 0, 3-5 = 3, 6-8 = 6

            for (int i = 0; i < 9; i++)
            {
                if (_sudokuBoard[row, i] == num) return false; // Kontrollerar radens position + col index 0-8
                if (_sudokuBoard[i, col] == num) return false; // Kontrollerar kolumnens position + row 0-8
                if (_sudokuBoard[rowStart + (i % 3), colStart + (i / 3)] == num) return false;
                // kontrollarer "boxen" index-positionen i rowStart respektive colStart
                // i%3 kommer ge index för row +1 +2
                // i/3 kommer att ge index +1, +2, +3
                // Då kontrolleras första index i "boxen" 2 rader ner och 3 kolumner bred.
            }
            return true;
        }

        #endregion
    }
}
