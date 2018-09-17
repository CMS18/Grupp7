using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string zen = "000000000000000000000000000000000000000100000000000000000000000000000000000000000";

            string easy = "619030040270061008000047621486302079000014580031009060005720806320106057160400030";

            Sudoku game = new Sudoku(easy);

            game.PrintSuduko();

            if(game.Solve())
            {
                game.PrintSuduko();
            }


            Console.ReadKey();

        }
    }
}
