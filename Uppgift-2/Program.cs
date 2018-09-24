using System;

namespace Uppgift_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string zen = "000000000000000000000000000000000000000100000000000000000000000000000000000000000";

            string easy = "619030040270061008000047621486302079000014580031009060005720806320106057160400030";

            var board = new Sudoku("000000000000000000000000000000000000000100000000000000000000000000000000000000000");

            board.PrintSudoku();

            Console.WriteLine("Press a key to solve...if you dare?");
            Console.ReadKey();
            Console.Clear();
            board.Solve();
        }


    }
}
