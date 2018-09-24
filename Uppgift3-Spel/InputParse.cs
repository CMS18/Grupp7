using System.Linq;
using System.Text.RegularExpressions;

namespace Uppgift3_Spel
{
    static class InputParse
    {
        private const string PlayerOptions = @"\bopen|drop|use|look|show|take|go|examine|read|pickup|inventory|turn|help|move\b";

        public static string ToPlayerAction(this string input)
        {
            Regex regex = new Regex(PlayerOptions);
            Match match = regex.Match(input);
            return match.Success ? match.Value : null;
        }

        public static bool CompareStrings(string compare, string compareTo)
        {
            var arrayValue = compare.Split(' ').ToArray();
            return arrayValue.Any(t => compareTo.ToLower().Contains(t.ToLower()));
        }
    }
}
