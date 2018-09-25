using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1
{
    class Program
    {
        private const string easy1 = "003020600900305001001806400008102900700000008006708200002609500800203009005010300";
        private const string easy2 = "619030040270061008000047621486302079000014580031009060005720806320106057160400030";
        private const string medium1 = "037060000205000800006908000000600024001503600650009000000302700009000402000050360";
        static void Main(string[] args)
        {
            Sudoku game = new Sudoku(easy1);

            game.BoardAsText();
            game.Solve();
        }
    }
}
