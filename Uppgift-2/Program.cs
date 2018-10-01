using System;

namespace Sudoku2
{
    class Program
    {

        private const string unsolvable1 =
            "009028700806004005003000004600000000020713450000000002300000500900400807001250300";

        private const string unsolvable2 =
            "090300001000080046000000800405060030003275600060010904001000000580020000200007060";

        private const string unsolvable3 =
            "000041000060000020002000000320600000000050041700000002000000230048000000501002000";

        private const string unsolvable4 =
            "900100004014030800003000090000708001800003000000000030021000070009040500500016003";

        private const string unsolvable5 =
            "04010035000000000000205000000408900260000012050300007004000160600007000010080020";


        static void Main(string[] args)
        {
            string easy = "619030040270061008000047621486302079000014580031009060005720806320106057160400030";
            string easy1 = "000000307048720010005014008250003876000000000671200039500840700030052980106000000";
            string easy2 = "409120030050903100000040089910004007020010060600800051780030000004709010090065408";
            string easy3 = "060001020970820400035004001604000018007000200820000605700900130002067094040500080";

            string medium = "000300000001080070980007610007900040204000308060008900075800031020060700000004000";
            string hard = "000004800590200004100800090001000508070000040309000100030001002200008067004900000";
            string expert = "060090020100000000070001800015300002000604000800005430003400050000000009050070060";
            string diabolic = "000000000000003085001020000000507000004000100090000000500000073002010000000040009";
            string diabolic2 = "900040000000010200370000005000000090001000400000705000000020100580300000000000000";
            string zen = "000000000000000000000000000000000000000010000000000000000000000000000000000000000";


            string test1 = "305420810487901506029056374850793041613208957074065280241309065508670192096512408"; // Singles
            string test2 = "002030008000008000031020000060050270010000050204060031000080605000000013005310400"; // Hidden SIngles
            string test3 = "090300001000080046000000800405060030003275600060010904001000000580020000200007060"; // Unsolveable

            Sudoku sudoku = new Sudoku(zen);
            sudoku.PrintSuduko();
            if (!sudoku.Solve())
            {
                // Ol�slig
               sudoku.SolveBasic();
            }
            sudoku.PrintSuduko();

            Console.ReadLine();

        }
    }
}
