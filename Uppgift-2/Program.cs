using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uppgift_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string zen = "000000000000000000000000000000000000000100000000000000000000000000000000000000000";

            string easy = "619030040270061008000047621486302079000014580031009060005720806320106057160400030";

            var board = new Sudoku(zen);

            board.PrintSudoku();

            Console.WriteLine("Press a key to solve...if you dare?");
            Console.ReadKey();
            Console.Clear();
            board.Solve();
        }


    }
}
